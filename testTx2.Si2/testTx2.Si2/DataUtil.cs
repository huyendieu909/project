using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace testTx2.Si2
{
    internal class DataUtil
    {
        string filename;
        XmlElement root;
        XmlDocument doc;
        public DataUtil()
        {
            filename = "congty.xml";
            doc = new XmlDocument();
            if (!File.Exists(filename))
            {
                root = doc.CreateElement("congty");
                doc.AppendChild(root);
                doc.Save(filename);
            }
            doc.Load(filename);
            root = doc.DocumentElement;
        }
        public List<NhanVien> Show()
        {
            XmlNodeList nodes = root.SelectNodes("nhanvien");
            List<NhanVien> nhanViens = new List<NhanVien>();
            foreach (XmlNode node in nodes)
            {
                NhanVien nv = new NhanVien();
                nv.MaNV = node.Attributes["manv"].Value;
                nv.HoTen = node.SelectSingleNode("hoten").InnerText;
                nv.Tuoi = int.Parse(node.SelectSingleNode("tuoi").InnerText);
                nv.Luong = Convert.ToDouble(node.SelectSingleNode("luong").InnerText);
                nv.Xa = node.SelectSingleNode("diachi/xa").InnerText;
                nv.Huyen = node.SelectSingleNode("diachi/huyen").InnerText;
                nv.Tinh = node.SelectSingleNode("diachi/tinh").InnerText;
                nv.DienThoai = node.SelectSingleNode("dienthoai").InnerText;
                nhanViens.Add(nv);
            }
            return nhanViens;
        }

        public void Add(NhanVien nv)
        {
            XmlAttribute manv = doc.CreateAttribute("manv");
            XmlElement nhanvien = doc.CreateElement("nhanvien");
            XmlElement hoten = doc.CreateElement("hoten");
            XmlElement tuoi = doc.CreateElement("tuoi");
            XmlElement luong = doc.CreateElement("luong");
            XmlElement diachi = doc.CreateElement("diachi");
            XmlElement xa = doc.CreateElement("xa");
            XmlElement huyen = doc.CreateElement("huyen");
            XmlElement tinh = doc.CreateElement("tinh");
            XmlElement dienthoai = doc.CreateElement("dienthoai");

            manv.InnerText = nv.MaNV;
            hoten.InnerText = nv.HoTen;
            tuoi.InnerText = nv.Tuoi.ToString();
            luong.InnerText = nv.Luong.ToString();
            xa.InnerText = nv.Xa;
            huyen.InnerText = nv.Huyen;
            tinh.InnerText = nv.Tinh;
            dienthoai.InnerText = nv.DienThoai;

            nhanvien.Attributes.Append(manv);
            diachi.AppendChild(xa);
            diachi.AppendChild(huyen);
            diachi.AppendChild(tinh);
            nhanvien.AppendChild(hoten);
            nhanvien.AppendChild(tuoi);
            nhanvien.AppendChild(luong);
            nhanvien.AppendChild(diachi);
            nhanvien.AppendChild(dienthoai);
            root.AppendChild(nhanvien);
            doc.Save(filename);
        }
        public void Delete(string manv)
        {
            XmlNode node = root.SelectSingleNode($"nhanvien[@manv='{manv}']");
            if (node != null)
            {
                root.RemoveChild(node);
                doc.Save(filename);
            }
            else
            {
                MessageBox.Show($"Nhân viên có mã {manv} không còn tồn tại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void Update(NhanVien nv)
        {
            XmlNode node = root.SelectSingleNode($"nhanvien[@manv='{nv.MaNV}']");
            if (node != null)
            {
                node.Attributes["manv"].Value = nv.MaNV;
                node.SelectSingleNode("hoten").InnerText = nv.HoTen;
                node.SelectSingleNode("tuoi").InnerText = nv.Tuoi.ToString();
                node.SelectSingleNode("luong").InnerText = nv.Luong.ToString();
                node.SelectSingleNode("diachi/xa").InnerText = nv.Xa;
                node.SelectSingleNode("diachi/huyen").InnerText = nv.Huyen;
                node.SelectSingleNode("diachi/tinh").InnerText = nv.Tinh;
                node.SelectSingleNode("dienthoai").InnerText = nv.DienThoai;
                doc.Save(filename);
            }
        }
        public bool MaNVDaTonTai(string manv)
        {
            XmlNode node = root.SelectSingleNode($"nhanvien[@manv='{manv}']");
            if (node != null) return true;
            else return false;
        }
    }
}
