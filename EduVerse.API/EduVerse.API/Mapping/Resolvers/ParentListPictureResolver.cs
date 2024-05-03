namespace EduVerse.API.Mapping.Resolvers
{
    public class ParentListPictureResolver : IValueResolver<ParentEntity, ParentListDTO, string>
    {
        private readonly AppConfig _config;

        public ParentListPictureResolver(IOptionsSnapshot<AppConfig> config)
        {
            _config = config.Value;
        }

        public string Resolve(ParentEntity source, ParentListDTO destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.PictureFileName))
            {
                return $"{_config.ApiHost}/{_config.ImgUrl}/no-image.jpg";
            }

            return $"{_config.ApiHost}/{_config.ImgUrl}/Parents/{source.PictureFileName}";
        }
    }
}
