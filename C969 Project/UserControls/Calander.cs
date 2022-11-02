using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Project.UserControls
{
    public partial class Calander : UserControl
    {
        const int DAYS_IN_A_WEEK = 7;
        const int WEEKS_IN_A_MONTH = 5;

        public Calander()
        {
            InitializeComponent();
        }

        public void UpdateMonth (int month, int year)
        {
            DateTime firstDay;
            DateTime lastDay;

            bool foundStartDay = false;

            int numDays = GetMonthBoundries(month, year, out firstDay, out lastDay);

            DayOfWeek startDay = firstDay.DayOfWeek;
            int i = 1;
            for (int y = 1; y < WEEKS_IN_A_MONTH + 1; y++)
            {
                for (int x = 0; x < DAYS_IN_A_WEEK; x++)
                {
                    int index = x + ((y - 1) * DAYS_IN_A_WEEK);
                    int totalCells = WEEKS_IN_A_MONTH * DAYS_IN_A_WEEK;
                    int reverseIndex = totalCells - index;

                    Label dayLbl = (Label)flwDays.Controls[index].Controls[0];
                    if (i > numDays)
                    {
                        dayLbl.Visible = false;
                        continue;
                    }

                    if ((int)startDay != x && !foundStartDay)
                    {
                        dayLbl.Visible = false;
                        continue;
                    }
                    else
                    {
                        foundStartDay = true;
                    }

                    dayLbl.Visible = true;
                    dayLbl.Text = i.ToString();
                    i++;
                }
            }
        }

        public int GetMonthBoundries (int month, int year, out DateTime firstDay, out DateTime lastDay)
        {
            firstDay = new DateTime(year, month, 1);
            lastDay = firstDay.AddMonths(1).AddSeconds(-1);

            return (lastDay - firstDay).Days + 1;
        }
    }
}
