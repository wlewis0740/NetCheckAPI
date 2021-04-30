using NetCheckAPI.Adapters;
using NetCheckAPI.Factories;
using NetCheckAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace NetCheckAPI.Services
{
    public class AdapterTaskService
    {
        private IAdapterFactory _adapterFactory;

        public AdapterTaskService (IAdapterFactory adapterFactory) {
            _adapterFactory = adapterFactory;
        }

        public async Task<Result[]> ExecuteAdapterTasks(List<string> services, string address) {
            var tasks = new List<Task<Result>>();
            foreach (string s in services) {
                tasks.Add(Task<Result>.Factory.StartNew(() => _adapterFactory.GetAdapter(s).GetResults(address)));
            }

            await Task.WhenAll(tasks);
            
            var results = new Result[tasks.Count];
            for (int i = 0; i < tasks.Count; i++) {
                results[i] = tasks[i].Result;
            }

            return results;
        }
    }
}