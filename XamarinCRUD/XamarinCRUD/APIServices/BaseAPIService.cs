﻿using XamarinCRUD.Helpers;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace XamarinCRUD.APIServices
{
    public static class BaseAPIService
    {
        private static HttpClient httpClient;
        private static HttpContent httpContent;

        public static async Task<T> Post<T>(string endpoint, object content, CancellationToken cancellationToken) where T : class
        {
            T response = null;

            try
            {
                httpClient = await NetworkHelper.CustomHttpClient().ConfigureAwait(false);
                httpContent = NetworkHelper.CreateHttpContent(content);

                HttpResponseMessage httpResponse = await httpClient.PostAsync(endpoint, httpContent, cancellationToken).ConfigureAwait(false);
                Stream stream = await httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
                response = NetworkHelper.DeserializeJsonFromStream<T>(stream);
            }
            catch (OperationCanceledException operationCanceledException)
            {
                Console.WriteLine(operationCanceledException.Message);
            }
            catch (HttpRequestException httpRequestException)
            {
                Console.WriteLine(httpRequestException.Message);
            }
            catch (MobileException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                LogHelper.WriteLog(exception, cancellationToken);
            }

            return response;
        }

        public static async Task<T> Put<T>(string endpoint, object content, CancellationToken cancellationToken) where T : class
        {
            T response = null;

            try
            {
                httpClient = await NetworkHelper.CustomHttpClient().ConfigureAwait(false);
                httpContent = NetworkHelper.CreateHttpContent(content);

                HttpResponseMessage httpResponse = await httpClient.PutAsync(endpoint, httpContent, cancellationToken).ConfigureAwait(false);
                Stream stream = await httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
                response = NetworkHelper.DeserializeJsonFromStream<T>(stream);
            }
            catch (OperationCanceledException operationCanceledException)
            {
                Console.WriteLine(operationCanceledException.Message);
            }
            catch (HttpRequestException httpRequestException)
            {
                Console.WriteLine(httpRequestException.Message);
            }
            catch (MobileException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                LogHelper.WriteLog(exception, cancellationToken);
            }

            return response;
        }

        public static async Task<T> Get<T>(string endpoint, CancellationToken cancellationToken) where T : class
        {
            T response = null;

            try
            {
                httpClient = await NetworkHelper.CustomHttpClient().ConfigureAwait(false);

                HttpResponseMessage httpResponse = await httpClient.GetAsync(endpoint, HttpCompletionOption.ResponseContentRead, cancellationToken).ConfigureAwait(false);
                Stream stream = await httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
                response = NetworkHelper.DeserializeJsonFromStream<T>(stream);
            }
            catch (OperationCanceledException operationCanceledException)
            {
                Console.WriteLine(operationCanceledException.Message);
            }
            catch (HttpRequestException httpRequestException)
            {
                Console.WriteLine(httpRequestException.Message);
            }
            catch (MobileException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                LogHelper.WriteLog(exception, cancellationToken);
            }

            return response;
        }

        public static async Task<T> Delete<T>(string endpoint, CancellationToken cancellationToken) where T : class
        {
            T response = null;

            try
            {
                httpClient = await NetworkHelper.CustomHttpClient().ConfigureAwait(false);

                HttpResponseMessage httpResponse = await httpClient.DeleteAsync(endpoint, cancellationToken).ConfigureAwait(false);
                Stream stream = await httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
                response = NetworkHelper.DeserializeJsonFromStream<T>(stream);
            }
            catch (OperationCanceledException operationCanceledException)
            {
                Console.WriteLine(operationCanceledException.Message);
            }
            catch (HttpRequestException httpRequestException)
            {
                Console.WriteLine(httpRequestException.Message);
            }
            catch (MobileException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                LogHelper.WriteLog(exception, cancellationToken);
            }

            return response;
        }
    }
}
