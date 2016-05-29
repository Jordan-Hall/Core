using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using JordanHall.Core.HttpClientFactory;
using JordanHall.Core.HttpClientFactory.DelegatingHandlers;
using JordanHall.IbmClassifierService.DelegatingHandlers;
using JordanHall.IbmClassifierService.Models;
using Newtonsoft.Json;

namespace JordanHall.IbmClassifierService
{
    public class IbmClasifierService : IIbmClasifierService
    {
        const string endPoint = "/natural-language-classifier/api/v1";
        private readonly IHttpRequester httpRequester;

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
            httpRequester = new HttpRequester(new Core.HttpClientFactory.HttpClientFactory(settings));
        }

        public async Task<bool> DeleteClassifier(string classifierId, CancellationToken cancellationToken)
        {
            return await httpRequester.Delete($"{endPoint}/classifiers/{classifierId}");
        }

        public async Task<Classifier> GetClassifierInformation(string classifierId, CancellationToken cancellationToken)
        {
            return await httpRequester.Get<Classifier>($"{endPoint}/classifiers/{classifierId}");
        }

        public async Task<ClassifierList> GetClassifiers(CancellationToken cancellationToken)
        {
            return await httpRequester.Get<ClassifierList>($"{endPoint}/classifiers");
        }

        public async Task<ClassifyResponse> GetClassification(ClassifyRequest request, CancellationToken cancellationToken)
        {
            return await httpRequester.Get<ClassifyResponse>($"{endPoint}/classifiers/{request.ClassifierId}/classify?text={request.Query}");
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
            return await httpRequester.Post<TrainingResponse>($"{endPoint}/classifiers", requestContent);
        }
    }
}
