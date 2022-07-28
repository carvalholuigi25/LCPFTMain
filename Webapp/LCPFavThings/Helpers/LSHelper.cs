using Blazorise.Extensions;
using Microsoft.JSInterop;

namespace LCPFavThings.Helpers
{
    #nullable enable

    public interface ILSHelper
    {
        Task Save(string key, string val);
        Task SaveByCl<T>(string key, T val) where T : class;
        Task<string> Get(string key);
        Task<T> GetByCl<T>(string key) where T : class;
        Task Delete(string key);
        Task ClearAll();
    }

	public class LSHelper : ILSHelper
	{
        private readonly IJSRuntime js;
        
        public LSHelper(IJSRuntime _js)
        {
            js = _js;
        }

        public async Task Save(string key, string val)
        {
            await js.InvokeVoidAsync("localStorage.setItem", key, val);
        }

        public async Task SaveByCl<T>(string key, T val) where T : class
        {
            await js.InvokeVoidAsync("localStorage.setItem", key, val);
        }

        public async Task<string> Get(string key)
        {
            return await js.InvokeAsync<string>("localStorage.getItem", key);
        }

        public async Task<T> GetByCl<T>(string key) where T : class
        {
            return await js.InvokeAsync<T>("localStorage.getItem", key);
        }

        public async Task Delete(string key)
        {
            await js.InvokeVoidAsync("localStorage.removeItem", key);
        }

        public async Task ClearAll()
        {
            await js.InvokeVoidAsync("localStorage.clear");
        }
    }
}
