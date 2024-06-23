namespace Catalog.Host.Models.Response
{
    public class UpdataResponse<T> : BaseResponce
    {
        public T? UpdataModel { get; set; }

        public override ResponceCode GetResponce() =>
            UpdataModel is null ?
            ResponceCode.Null :
            ResponceCode.Seccusfull;
    }
}
