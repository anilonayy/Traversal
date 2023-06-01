using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRApiForSql.DAL;
using SignalRApiForSql.Hubs;

namespace SignalRApiForSql.Model
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
            await _hubContext.Clients.All.SendAsync("CallVisitorList",GetVisitorChartList());
        }

        public List<VisitorChart> GetVisitorChartList()
        {
            List<VisitorChart> visitorCharts = new List<VisitorChart>();

            using(var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select * From\r\ncrosstab(\r\n\t'\r\n\tSelect  \"VisitDate\",\"City\",\"CityVisitCount\"\r\n\tFrom \"Visitors\"\r\n\t'\r\n)\r\n as ct(\"VisitDate\" date,city1 int,city2 int,city3 int,city4 int,city5 int)";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                
                using(var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        VisitorChart chart = new VisitorChart();
                        chart.VisitDate = reader.GetDateTime(0).ToShortDateString();
                        Enumerable.Range(1, 5).ToList().ForEach(x =>
                        {
                            chart.Counts.Add(reader.GetInt32(x));
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
