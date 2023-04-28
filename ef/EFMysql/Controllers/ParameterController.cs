using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFMysql.Controllers
{

    [Route("api/")]
    [ApiController]
    public class ParameterController : ControllerBase
    {
        private readonly ILogger<ParameterController> _logger;
        ParameterContext ParameterContext;

        public ParameterController(ParameterContext ParameterContext, ILogger<ParameterController> logger)
        {
            _logger = logger;
            this.ParameterContext = ParameterContext;
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        //查找表中所有数据
        [HttpGet("parameter/getall")]
        public IActionResult GetAll()
        {
            List<Parameter> ParameterTable = ParameterContext.Parameter.ToList();  //查出所有
            return Ok(ParameterTable);
        }

        /// <summary>
        /// 添加新数据
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        //添加一个数据，传入一个不带ID的
        [HttpPost("parameter/postone")]
        public IActionResult PostOne(Parameter parameter)
        {
            var Parameter = ParameterContext.Parameter.FirstOrDefault(a => a.Id == parameter.Id);
            if (Parameter != null)
            {
                return BadRequest(new { conut = -1, msg = "添加失败，id重复" });
            }
            ParameterContext.Parameter.Add(parameter);  //添加一个
            int e = ParameterContext.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        //修改数据,传入对象，找到对应id的数据实现更新
        [HttpPost("parameter/modifyone")]
        public IActionResult Modify(Parameter parameter)
        {
            var Parameter = ParameterContext.Parameter.FirstOrDefault(a => a.Id == parameter.Id);
            if (Parameter == null)
            {
                return BadRequest(new { conut = -1, msg = "修改失败，未找到数据" });
            }
            //修改数据
            // ParameterTable.Id = parameter.Id;
            Parameter.Ceiling = parameter.Ceiling;
            Parameter.Swith = parameter.Swith;
            Parameter.Limit = parameter.Limit;
            Parameter.Name = parameter.Name;
            Parameter.Type = parameter.Type;
            Parameter.Plcaddress = parameter.Plcaddress;

            ParameterContext.Parameter.Update(Parameter);
            ParameterContext.SaveChanges();
            return Ok(parameter);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        //移除一个对象，根据id移除
        [HttpPost("parameter/Removeone")]
        public IActionResult Remove(Parameter parameter)
        {
            var Parameter = ParameterContext.Parameter.FirstOrDefault(a => a.Id == parameter.Id);
            //修改数据

            if (Parameter == null)
            {
                return NotFound();
            }
            ParameterContext.Parameter.Remove(Parameter);
            ParameterContext.SaveChanges();
            return Ok(Parameter);
        }

        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("parameter/GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var model = await ParameterContext.Parameter.FindAsync(id);
            return Ok(model);
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("parameter/GetBypage")]
        public async Task<IActionResult> GetBypage(int pageIndex, int pageSize)
        {
            List<Parameter> list = new List<Parameter>();
            list = ParameterContext.Parameter.ToList()
                .OrderBy(m => m.Id)//卡号排序倒序
                .Skip((pageIndex - 1) * pageSize)//获取（Skip）第（(pageIndex - 1) * pageSize）行后的数据，也就是第(pageIndex - 1) 以后的数据
                .Take(pageSize)//减去（Take）第pageSize行后的数据就得到了第pageIdex页
                .ToList();
            return Ok(list);

        }
        /// <summary>
        /// 添加新数据
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        //添加一个数据，传入一个不带ID的
        [HttpPost("test/testadd")]
        public IActionResult testadd(test parameter)
        {
            var Parameter = ParameterContext.test.FirstOrDefault(a => a.Id == parameter.Id);
            if (Parameter != null)
            {
                return BadRequest(new { conut = -1, msg = "添加失败，id重复" });
            }
            ParameterContext.test.Add(parameter);  //添加一个
            int e = ParameterContext.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// 添加新数据
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        //添加一个数据，传入一个不带ID的
        [HttpPost("test/testshow")]
        public IActionResult show(test parameter)
        {//我也新提交溜了一个
            return Ok();
        }
    }
}
