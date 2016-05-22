using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using JordanHall.ClassifierService.DelegatingHandlers;
using JordanHall.ClassifierService.Models;
using JordanHall.Core.DelegatingHandlers;
using JordanHall.Core.HttpClientFactory;
using Newtonsoft.Json;

namespace JordanHall.ClassifierService
{
    public class IbmClasifierService : IIbmClasifierService
    {
        private readonly Core.HttpClientFactory.HttpClientFactory clientFactory;

        public IbmClasifierService()
        {
            var settings = new HttpClientSettings()
            {
                Handlers = new List<DelegatingHandler>()
                {
                    new BasicAuthorizationHandler(
                        ConfigurationManager.AppSettings["IbmClasifierUsername"],
                        ConfigurationManager.AppSettings["IbmClasifierPassword"]
                    ),
                    new HandingExceptionDelegatingHandler()
                },
                BaseUri = new Uri(ConfigurationManager.AppSettings["IbmClasifierBaseUrl"])
            };
            clientFactory = new Core.HttpClientFactory.HttpClientFactory(settings);
        }

        public async Task<bool> DeleteClassifier(string classifierId, CancellationToken cancellationToken)
        {
            using (var client = clientFactory.CreateClient())
            {
                var httpResponse = await client.DeleteAsync($"/classifiers/{classifierId}", cancellationToken);

                if (httpResponse.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<Classifier> GetClassifierInformation(string classifierId, CancellationToken cancellationToken)
        {
            using (var client = clientFactory.CreateClient())
            {
                var httpResponse = await client.GetAsync($"/classifiers/{classifierId}", cancellationToken);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Classifier>(content);
                }
            }
            return null;
        }

        public async Task<IEnumerable<Classifier>> GetClassifiers(CancellationToken cancellationToken)
        {
            using (var client = clientFactory.CreateClient())
            {
                var httpResponse = await client.GetAsync("/classifiers", cancellationToken);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<Classifier>>(content);
                }
            }
            return null;
        }

        public async Task<ClassifyResponse> PostQuery(ClassifyRequest request, CancellationToken cancellationToken)
        {
            using (var client = clientFactory.CreateClient())
            {
                var httpResponse = await client.PostAsJsonAsync("/classifiers", request, cancellationToken);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ClassifyResponse>(content);
                }
            }
            return null;
        }

        public async Task<TrainingResponse> PostTrainingData(TrainingRequest trainingRequest, CancellationToken cancellationToken)
        {
            var requestContent = new MultipartFormDataContent
            {
                {
                    new StreamContent(new MemoryStream(trainingRequest.FileBytes)), "training_data",
                    trainingRequest.FileName
                }
            };
            using (var client = clientFactory.CreateClient())
            {
                var httpResponse = await client.PostAsync("/classifiers", requestContent, cancellationToken);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TrainingResponse>(content);
                }
            }
            return null;
        }

        
    }
}
