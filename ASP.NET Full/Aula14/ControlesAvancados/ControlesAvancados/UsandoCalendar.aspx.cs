using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace ControlesAvancados
{
    public partial class UsandoCalendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            lblDatas.Text = "Você selecionou as seguintes datas:<br />";
            foreach (DateTime dt in Calendar1.SelectedDates)
            {
                lblDatas.Text += dt.ToLongDateString() + "<br />";
            }
            lblDatas.Visible = true;

            lbxHoras.Items.Clear();
            switch (Calendar1.SelectedDate.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    lbxHoras.Items.Add("10:00");
                    lbxHoras.Items.Add("10:30");
                    lbxHoras.Items.Add("11:00");
                    break;
                default:
                    lbxHoras.Items.Add("10:00");
                    lbxHoras.Items.Add("10:30");
                    lbxHoras.Items.Add("11:00");
                    lbxHoras.Items.Add("11:30");
                    lbxHoras.Items.Add("12:00");
                    lbxHoras.Items.Add("12:30");
                    break;
            }
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            //// se for domingo não será selecionável
            //if (e.Day.Date.DayOfWeek == 0)
            ////se for fim de semana ou dia anterior a hoje, a data
            ////não será selecionável
            ////if (e.Day.IsWeekend || e.Day.Date < DateTime.Now.Date)
            //{
            //    e.Day.IsSelectable = false;
            //    e.Cell.BackColor = Color.Yellow;
            //}

            //DayRender avançado
            if (e.Day.IsWeekend || e.Day.Date < DateTime.Now.Date)
            {
                e.Day.IsSelectable = false;
                Label lblMsg = new Label();
                lblMsg.Text = "<br /> Não útil";
                e.Cell.Controls.Add(lblMsg);
            }
            if (!e.Day.IsSelected && !e.Day.IsToday)
            {
                e.Cell.BackColor = Color.Yellow;
            } 

        }

        protected void lbxHoras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxHoras.SelectedItem.Text.Length <= 5)
            {
                btnAgendar.Visible = true;
                txtCompromisso.Visible = true;
            }
            else
            {
                txtCompromisso.Visible = false;
                btnAgendar.Visible = false;
                lblDatas.Text = "Já existe agendamento para este horário.";
            }
        }

        protected void btnAgendar_Click(object sender, EventArgs e)
        {
            if (lbxHoras.SelectedItem.Text.Length <= 5)
            {
                lbxHoras.SelectedItem.Text += " - " +
                    txtCompromisso.Text;
                txtCompromisso.Text = "";
                txtCompromisso.Visible = false;
                btnAgendar.Visible = false;
            }
            
        }

    }
}
