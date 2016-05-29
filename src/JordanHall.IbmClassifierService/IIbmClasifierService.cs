using System.Threading;
using System.Threading.Tasks;
using JordanHall.IbmClassifierService.Models;

namespace JordanHall.IbmClassifierService
{
    public interface IIbmClasifierService
    {
        Task<TrainingResponse> PostTrainingData(TrainingRequestModel trainingRequest, CancellationToken cancellationToken);
        Task<ClassifierList> GetClassifiers(CancellationToken cancellationToken);
        Task<Classifier> GetClassifierInformation(string classifierId, CancellationToken cancellationToken);
        Task<bool> DeleteClassifier(string classifierId, CancellationToken cancellationToken);
        Task<ClassifyResponse> GetClassification(ClassifyRequest request, CancellationToken cancellationToken);
    }
}
