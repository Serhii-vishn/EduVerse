namespace EduVerse.API.Mapping.Resolvers
{
    public class TeacherListPictureResolver : IValueResolver<TeacherEntity, TeacherListDTO, string>
    {
        private readonly AppConfig _config;

        public TeacherListPictureResolver(IOptionsSnapshot<AppConfig> config)
        {
            _config = config.Value;
        }

        public string Resolve(TeacherEntity source, TeacherListDTO destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.PictureFileName))
            {
                return $"{_config.ApiHost}/{_config.ImgUrl}/no-image.jpg";
            }

            return $"{_config.ApiHost}/{_config.ImgUrl}/Teachers/{source.PictureFileName}";
        }
    }
}
