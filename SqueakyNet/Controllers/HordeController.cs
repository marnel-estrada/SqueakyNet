using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SqueakyNet.Controllers {
    public class HordeController : Controller {

        private static Dictionary<string, string> CATS = new Dictionary<string, string>();

        [HttpGet("horde/add/{cat}")]
        public string Add(string cat, string sound) {
            CATS[cat] = sound;
            return string.Format("{0} added to the horde!", cat);
        }

        [HttpPost("horde/{cat}")]
        public string PostAdd(string cat, [FromBody]string sound) {
            CATS[cat] = sound;
            return string.Format("{0} added to the horde! (post)", cat);
        }

        [HttpGet("horde/{cat}")]
        public string Get(string cat) {
            if (CATS.ContainsKey(cat)) {
                return CATS[cat];
            }

            return "Cat not found: " + cat;
        }

        [HttpPatch("horde/{cat}")]
        public string Patch(string cat, [FromBody]string sound) {
            if (CATS.ContainsKey(cat)) {
                CATS[cat] = sound;
                return "Cat " + cat + " updated";
            }

            return "Cat " + cat + " not found.";
        }

        [HttpDelete("horde/{cat}")]
        public string Delete(string cat) {
            if (CATS.ContainsKey(cat)) {
                CATS.Remove(cat);
                return "Cat " + cat + " deleted";
            }

            return "Cat " + cat + " not found.";
        }

    }
}
