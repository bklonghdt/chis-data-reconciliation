using DataReconciliation.Models;
using Ganss.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace DataReconciliation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataReconciliationController : ControllerBase
    {

        private PropertyInfo[] getProperties()
        {
            Type LTType = typeof(Laytesting);
            return LTType.GetProperties();
        }

        /// <summary>
        /// Nhận danh sách file cần đối soát và trả ra các dữ liệu cùng global id nhưng khác giá trị 
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(List<IFormFile> files)
        {
            //Đọc danh sách file và kiểm tra file có trùng tên không
            var fDict = new Dictionary<string, string>();
            foreach (var file in files)
            {
                if (fDict.TryGetValue(file.FileName, out var f))
                {
                    return BadRequest("file name must be unique");
                }
                else
                {
                    fDict.Add(file.FileName, "");
                }
            }
            var fileNames = fDict.Select(_ => _.Key).ToList();
            var fileCount = fileNames.Count;
            var data = new List<FileValue>();

            //Lấy danh sách trường dữ liệu cần đối soát
            var fields = getProperties().ToList();


            //Đọc dữ liệu từ file
            files.ForEach(f =>
            {
                var l = new List<Laytesting>();
                //Đọc dữ liệu nếu file là excel
                if (f.FileName.EndsWith(".xlsx"))
                {
                    using var ms = new MemoryStream();

                    f.CopyTo(ms);
                    l = (new ExcelMapper(ms).Fetch<Laytesting>()).ToList();
                }
                //Đọc dữ liệu nếu file là json
                if (f.FileName.EndsWith(".json"))
                {
                    using var ms = new MemoryStream();

                    f.CopyTo(ms);
                    l = JsonConvert.DeserializeObject<List<Laytesting>>(Encoding.UTF8.GetString(ms.ToArray()));
                }

                //Tạo dữ liệu theo bộ [tên file, tên trường dữ liệu, global id, giá trị]
                foreach (var item in l)
                {
                    fields.ForEach(field =>
                    {
                        var value = field.GetValue(item);
                        var row = new FileValue
                        {
                            FieldName = field.Name,
                            Id = item.global_id,
                            FileName = f.FileName,
                            Value = value != null ? value.ToString() : "NO_DATA",
                        };
                        if (field.PropertyType == typeof(int?))
                        {
                            if (value != null && (int)value == 0)
                            {
                                row.Value = "NO_DATA";
                            }
                        }
                        if(field.PropertyType == typeof(string))
                        {
                            if (value != null && value.ToString() == "0")
                            {
                                row.Value = "NO_DATA";
                            }
                        }
                        data.Add(row);
                    });
                }
            });

            //danh sách kết quả
            var rs = new List<Result>();
            var succeed = new List<Result>();

            //nhóm dữ liệu theo từng id
            data.GroupBy(_ => _.Id).ToList().ForEach(item =>
            {
                var id = item.Key;

                var fail = false;

                //nhóm dữ liệu theo từng field
                item.GroupBy(_ => _.FieldName).ToList().ForEach(field =>
                {
                    //nhóm dữ liệu theo giá trị của field đó 
                    var d = field.GroupBy(_ => _.Value);

                    //trường hợp có nhiều hơn 1 giá trị (có khác biệt ở các nguồn)
                    if (d.Count() != 1)
                    {
                        var error = new List<string>();
                        d.ToList().ForEach(value =>
                        {
                            var n = string.Join(", ", value.Select(_ => _.FileName));
                            fail = true;
                            error.Add($"{n}: {value.Key}");
                        });
                        var errorMessage = string.Join("; ", error);
                        rs.Add(new Result
                        {
                            Global_id = id,
                            Field = field.Key,
                            Error = true,
                            Message = errorMessage
                        });
                    }
                    //trường hợp cùng 1 global id nhưng không xuất hiện ở tất cả các file
                    if (field.Count() != fileCount)
                    {
                        fail = true;
                        rs.Add(new Result
                        {
                            Global_id = id,
                            Field = field.Key,
                            Error = true,
                            Message = $"Number of value is not equal number of file (files have data: {string.Join(", ", field.Select(_ => _.FileName))})"
                        });
                    }
                });
                if (!fail)
                {
                    rs.Add(new Result
                    {
                        Global_id = id,
                        Error = false,
                        Message = "Done"
                    });
                }
            });

            using (var ms = new MemoryStream())
            {
                var excel = new ExcelMapper();
                excel.Save(ms, rs, "result");
                return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{DateTime.Now.Ticks}.xlsx");
            }
        }
    }
}
