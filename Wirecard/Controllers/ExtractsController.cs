﻿using Newtonsoft.Json;
using System.Net.Http;
using Wirecard.Models;
using System.Threading.Tasks;
using Wirecard.Exception;
using System.Collections.Generic;

namespace Wirecard.Controllers
{
    //Extratos - Extracts
    public partial class ExtractsController : BaseController
    {
        #region Singleton Pattern
        private static readonly object syncObject = new object();
        private static ExtractsController instance = null;
        internal static ExtractsController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new ExtractsController();
                    }
                }
                return instance;
            }
        }
        #endregion Singleton Pattern

        /// <summary>
        /// Listar Extrato - List Extract
        /// </summary>
        /// <param name="begin">Data de início de exibição no formato YYYY-MM-DD.</param>
        /// <param name="end">Data de fim de exibição no formato YYYY-MM-DD.</param>
        /// <returns></returns>
        public async Task<ExtractResponse> List(string begin, string end)
        {
            HttpResponseMessage response = await ClientInstance.GetAsync($"v2/statements?begin={begin}&end={end}");
            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                WirecardException.WirecardError wirecardException = WirecardException.DeserializeObject(content);
                throw new WirecardException(wirecardException, "HTTP Response Not Success", content, (int)response.StatusCode);
            }
            try
            {
                return JsonConvert.DeserializeObject<ExtractResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Detalhes do Extrato - Extract Details
        /// </summary>
        /// <param name="type">Tipo do extrato</param>
        /// <param name="date">Data para visualizar os detalhes no formato YYYY-MM-DD.</param>
        /// <returns></returns>
        public async Task<ExtractResponse> Detail(string type, string date)
        {
            HttpResponseMessage response = await ClientInstance.GetAsync($"v2/statements/details?type={type}&date={date}");
            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                WirecardException.WirecardError wirecardException = WirecardException.DeserializeObject(content);
                throw new WirecardException(wirecardException, "HTTP Response Not Success", content, (int)response.StatusCode);
            }
            try
            {
                return JsonConvert.DeserializeObject<ExtractResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Listar Extrato Futuro - List Future Extract
        /// </summary>
        /// <param name="begin">Data de início de exibição no formato YYYY-MM-DD.</param>
        /// <param name="end">Data de fim de exibição no formato YYYY-MM-DD.</param>
        /// <returns></returns>
        public async Task<ExtractResponse> ListFuture(string begin, string end)
        {
            HttpResponseMessage response = await ClientInstance.GetAsync($"v2/futurestatements?begin={begin}&end={end}");
            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                WirecardException.WirecardError wirecardException = WirecardException.DeserializeObject(content);
                throw new WirecardException(wirecardException, "HTTP Response Not Success", content, (int)response.StatusCode);
            }
            try
            {
                return JsonConvert.DeserializeObject<ExtractResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Listar Extrato Futuro - List Future Extract
        /// </summary>
        /// <param name="type">Tipo do extrato.</param>
        /// <param name="date">Data para visualizar os detalhes no formato YYYY-MM-DD.</param>
        /// <returns></returns>
        public async Task<ExtractResponse> DetailFuture(string type, string date)
        {
            HttpResponseMessage response = await ClientInstance.GetAsync($"v2/futurestatements/details?type={type}&date={date}");
            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                WirecardException.WirecardError wirecardException = WirecardException.DeserializeObject(content);
                throw new WirecardException(wirecardException, "HTTP Response Not Success", content, (int)response.StatusCode);
            }
            try
            {
                return JsonConvert.DeserializeObject<ExtractResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}