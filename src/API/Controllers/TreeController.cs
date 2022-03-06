using Microsoft.AspNetCore.Mvc;
using Trees;

namespace API.Controllers
{
    [Route("trees")]
    public class TreeController : Controller
    {
        [HttpGet,Route("bst")]
        public IActionResult Index()
        {
            var array = BuildArray(500);
            var bst = new BinarySearchTree<int,int>();
            foreach(var item in array)
            {
                bst.TryAdd(item.Item1, item.Item2);
            }
            return Ok(bst.Root);
            
        }


        private (int,int)[] BuildArray(int seedCount)
        {
            var values = new (int, int)[seedCount];
            for (int i = 0; i < seedCount; i++)
            {
                values[i] = (i + 1, i + 1);
            }
            var random = new Random();
            var randomised = values.OrderBy(x => random.Next(10000)).ToArray();
            return randomised;
        }
    }
}
