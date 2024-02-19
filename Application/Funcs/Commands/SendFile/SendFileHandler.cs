using MediatR;
using Microsoft.Extensions.Configuration;
using Roadmap.Application.Funcs.Commands.StatusFile;
using Roadmap.Application.Interfaces;
using Minio;
using Minio.DataModel.Args;

namespace Roadmap.Application.Funcs.Commands.SendFile;

public class SendFileHandler : IRequestHandler<SendFileCommand>
{
    private readonly IConfiguration _configuration; // Внедрение зависимости IConfiguration

    public SendFileHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task Handle(SendFileCommand request, CancellationToken cancellationToken)
    {
        var endpoint = _configuration.GetValue<string>("Endpoint");
        var accessKey = _configuration.GetValue<string>("AccessKey");
        var secretKey = _configuration.GetValue<string>("SecretKey");
        var minio = new MinioClient()
            .WithEndpoint(endpoint)
            .WithCredentials(accessKey, secretKey)
            .WithSSL(false)
            .Build();
        try
        {
            var beArgs = new BucketExistsArgs().WithBucket("mybucket");
            bool found = await minio.BucketExistsAsync(beArgs).ConfigureAwait(false);
            if (!found)
            {
                var mbArgs = new MakeBucketArgs()
                    .WithBucket("mybucket");
                await minio.MakeBucketAsync(mbArgs).ConfigureAwait(false);
            }

            var putObjectArgs = new PutObjectArgs()
                .WithBucket("mybucket")
                .WithObject(request.File.FileName)
                .WithContentType(request.File.ContentType)
                .WithStreamData(request.File.OpenReadStream())
                .WithObjectSize(request.File.Length);

            await minio.PutObjectAsync(putObjectArgs).ConfigureAwait(false);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }

}