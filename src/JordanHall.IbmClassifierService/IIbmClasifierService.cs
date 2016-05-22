using System.Collections.Generic;
using System.Threading.Tasks;
using JordanHall.ClassifierService.Models;
using System.Threading;

namespace JordanHall.ClassifierService
{
    public interface IIbmClasifierService
    {
        Task<TrainingResponse> PostTrainingData(TrainingRequest trainingRequest, CancellationToken cancellationToken);
        Task<IEnumerable<Classifier>> GetClassifiers(CancellationToken cancellationToken);
        Task<Classifier> GetClassifierInformation(string classifierId, CancellationToken cancellationToken);
        Task<bool> DeleteClassifier(string classifierId, CancellationToken cancellationToken);
        Task<ClassifyResponse> PostQuery(ClassifyRequest request, CancellationToken cancellationToken);
    }
}
