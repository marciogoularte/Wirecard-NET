﻿using MoipCSharp.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoipCSharp
{
    public static class ContaClassica
    {
        public static async Task<HttpStatusCode> VerificarSeUsuarioJaPossuiContaMoip(HttpClient httpClient, string email)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"v2/accounts/exists?email={email}");
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ArgumentException(await response.Content.ReadAsStringAsync());
            }
            return response.StatusCode;
        }
        public static async Task<CriarContaMoipClassicaResponse> CriarContaMoipClassica(HttpClient httpClient, CriarContaMoipClassicaRequest body)
        {         
            HttpResponseMessage response = await httpClient.PostAsync("v2/accounts", null);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ArgumentException(await response.Content.ReadAsStringAsync());
            }
            try
            {
                return JsonConvert.DeserializeObject<CriarContaMoipClassicaResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error message: " + ex.Message);
            }
        }
        public static async Task<ConsultarContaMoipResponse> ConsultarContaMoip(HttpClient httpClient, string account_id)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"v2/accounts/{account_id}");
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ArgumentException(await response.Content.ReadAsStringAsync());
            }
            try
            {
                return JsonConvert.DeserializeObject<ConsultarContaMoipResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error message: " + ex.Message);
            }
        }
        public static async Task<string> SolicitarPermissoesAcessoUsuario(HttpClient httpClient, string response_type, string client_id, string redirect_uri, string scope)
        {
            httpClient.BaseAddress = new Uri("https://connect-sandbox.moip.com.br/");
            HttpResponseMessage response = await httpClient.GetAsync($"oauth/authorize?response_type={response_type}&client_id={client_id}&redirect_uri={redirect_uri}&scope={scope}");
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ArgumentException(await response.Content.ReadAsStringAsync());
            }
            try
            {
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error message: " + ex.Message);
            }
        }
        public static async Task<GerarAccessTokenResponse> GerarAccessToken(HttpClient httpClient, string client_id, string client_secret, string redirect_uri, string grant_type, string code)
        {
            httpClient.BaseAddress = new Uri("https://connect-sandbox.moip.com.br/");
            HttpResponseMessage response = await httpClient.PostAsync($"oauth/token?client_id={client_id}&client_secret={client_secret}&redirect_uri={redirect_uri}&grant_type{grant_type}&code={code}", null);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ArgumentException(await response.Content.ReadAsStringAsync());
            }
            try
            {
                return JsonConvert.DeserializeObject<GerarAccessTokenResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error message: " + ex.Message);
            }
        }
        public static async Task<AtualizarAccessTokenResponse> AtualizarAccessToken(HttpClient httpClient, string grant_type, string refresh_token)
        {
            httpClient.BaseAddress = new Uri("https://connect-sandbox.moip.com.br/");
            HttpResponseMessage response = await httpClient.PostAsync($"oauth/token?grant_type={grant_type}&refresh_token={refresh_token}", null);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ArgumentException(await response.Content.ReadAsStringAsync());
            }
            try
            {
                return JsonConvert.DeserializeObject<AtualizarAccessTokenResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error message: " + ex.Message);
            }
        }
        public static async Task<ObterChavePublicaContaMoipResponse> ObterChavePublicaContaMoip(HttpClient httpClient)
        {
            HttpResponseMessage response = await httpClient.GetAsync("v2/keys");
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ArgumentException(await response.Content.ReadAsStringAsync());
            }
            try
            {
                return JsonConvert.DeserializeObject<ObterChavePublicaContaMoipResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error message: " + ex.Message);
            }
        }
    }
}
