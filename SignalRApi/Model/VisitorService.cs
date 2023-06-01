using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRApi.DAL;
using SignalRApi.Hubs;

namespace SignalRApi.Model
{
    public class VisitorService
    {
        private readonly Context _context;
        private readonly IHubContext<VisitorHub> _hubContext;

        public VisitorService(Context context, IHubContext<VisitorHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }


        public IQueryable<Visitor> GetList()
        {
            return _context.Visitors.AsQueryable();
        }

        public async Task SaveVisitor(Visitor visitor)
        {
            await _context.Visitors.AddAsync(visitor);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("ReceiveVisitorList", GetVisitorChartList());
        }

        public List<VisitorChart> GetVisitorChartList()
        {
            List<VisitorChart> visitorCharts = new List<VisitorChart>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select tarih, [1], [2], [3], [4], [5] \r\nfrom \r\n(select[City], CityVisitCount, Cast([VisitDate] as\r\nDate) as tarih from Visitors) \r\nas visitTable Pivot (Sum(CityVisitCount) For City in([1],\r\n[2], [3], [4],[5])) as pivottable order by tarih asc;";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VisitorChart chart = new VisitorChart();
                        chart.VisitDate = reader.GetDateTime(0).ToShortDateString();
                        Enumerable.Range(1, 5).ToList().ForEach(x =>
                        {
                            if (DBNull.Value.Equals(reader[x]))
                            {
                                chart.Counts.Add(0);   
                            }
                            else
                            {
                                chart.Counts.Add(reader.GetInt32(x));

                            }

                        });

                        visitorCharts.Add(chart);

                    }
                }
                _context.Database.CloseConnection();
                return visitorCharts;

            }
        }


    }
}
