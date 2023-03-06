using System;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Text;
//using System.Xml;

class Order
{
    public string Name_Order { set; get; }
    public int Count { set; get; }
    public string Color_Order { set; get; }
}
namespace _06._03._2023XML
{
    class Program
    {
       static void Main(string[] args)
        {
            Order order = new Order();
            order.Name_Order = "Apple";
            order.Count = 3;
            order.Color_Order = "Read";
            string r = Convert.ToString(order.Count);

            XmlTextWriter xml = new XmlTextWriter("../../Order.xml", Encoding.UTF8);
            xml.Formatting = Formatting.Indented;
            xml.WriteStartElement("Orde");
            xml.WriteStartElement("Order_1");
            xml.WriteStartAttribute("Низвание заказа -->");
            xml.WriteString(order.Name_Order);
            xml.WriteStartAttribute("Количество -->");
            xml.WriteString(r);
            xml.WriteStartAttribute("Цвет заказа -->");
            xml.WriteString(order.Color_Order);
            xml.Close();

            XmlTextReader read1= new XmlTextReader("../../Order.xml");
            string Str = null;
            while (read1.Read())
            {
                if (read1.NodeType==XmlNodeType.Text)
                {
                    Str += read1.Value;
                }
                if (read1.NodeType==XmlNodeType.Element)
                {
                    if (read1.HasAttributes)
                    {
                        Str += read1.Value;
                    }
                }
            }
            Console.WriteLine(Str + "\n");
            read1.Close();
        }
    }
}
