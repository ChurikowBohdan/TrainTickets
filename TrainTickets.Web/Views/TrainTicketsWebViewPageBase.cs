using Abp.Web.Mvc.Views;

namespace TrainTickets.Web.Views
{
    public abstract class TrainTicketsWebViewPageBase : TrainTicketsWebViewPageBase<dynamic>
    {

    }

    public abstract class TrainTicketsWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected TrainTicketsWebViewPageBase()
        {
            LocalizationSourceName = TrainTicketsConsts.LocalizationSourceName;
        }
    }
}