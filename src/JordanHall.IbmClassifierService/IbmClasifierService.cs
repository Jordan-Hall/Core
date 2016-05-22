using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using JordanHall.Core.DelegatingHandlers;
using JordanHall.Core.HttpClientFactory;
using JordanHall.IbmClassifierService.DelegatingHandlers;
using JordanHall.IbmClassifierService.Models;
using Newtonsoft.Json;

namespace JordanHall.IbmClassifierService
{
    public class IbmClasifierService : IIbmClasifierService
    {
        const string endPoint = "/natural-language-classifier/api/v1";
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
                var httpResponse = await client.DeleteAsync($"{endPoint}/classifiers/{classifierId}", cancellationToken);

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
                var httpResponse = await client.GetAsync($"{endPoint}/classifiers/{classifierId}", cancellationToken);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Classifier>(content);
                }
            }
            return null;
        }

        public async Task<ClassifierList> GetClassifiers(CancellationToken cancellationToken)
        {
            using (var client = clientFactory.CreateClient())
            {
                var httpResponse = await client.GetAsync($"{endPoint}/classifiers", cancellationToken);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ClassifierList>(content);
                }
            }
            return null;
        }

        public async Task<ClassifyResponse> PostQuery(ClassifyRequest request, CancellationToken cancellationToken)
        {
            using (var client = clientFactory.CreateClient())
            {
                var httpResponse = await client.GetAsync($"{endPoint}/classifiers/{request.ClassifierId}/classify?text={request.Query}", cancellationToken);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ClassifyResponse>(content);
                }
            }
            return null;
        }

        public async Task<TrainingResponse> PostTrainingData(TrainingRequestModel trainingRequest, CancellationToken cancellationToken)
        {
            var requestContent = new MultipartFormDataContent
            {
                {
                    new StreamContent(new MemoryStream(trainingRequest.FileBytes)), "training_data"
                },
                {
                    new StringContent(JsonConvert.SerializeObject(new TrainingRequest() {Language =  trainingRequest.Language, Name= trainingRequest.Name})),
                    "training_metadata"
                }
            };
            using (var client = clientFactory.CreateClient())
            {
                var httpResponse = await client.PostAsync($"{endPoint}/classifiers", requestContent, cancellationToken);

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
