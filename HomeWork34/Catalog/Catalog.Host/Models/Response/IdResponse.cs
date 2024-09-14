namespace Catalog.Host.Models.Response
{
    public class IdResponse : BaseResponce
    {
        public int? Id { get; set; }
        public override ResponceCode GetResponce() =>
            Id is null ?
            ResponceCode.Null :
            ResponceCode.Seccusfull;
    }
}
