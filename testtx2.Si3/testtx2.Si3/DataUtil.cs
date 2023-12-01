using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace testtx2.Si3
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
            List<NhanVien> nhanViens = new List<NhanVien>();
            XmlNodeList nodes = root.SelectNodes("nhanvien");
            foreach (XmlNode node in nodes)
            {
                NhanVien nv = new NhanVien();
                nv.MaNV = node.Attributes["manv"].Value;
                nv.HoTen = node.SelectSingleNode("hoten").InnerText;
                nv.Tuoi = int.Parse(node.SelectSingleNode("tuoi").InnerText);
                nv.Luong = double.Parse(node.SelectSingleNode("luong").InnerText);
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
            XmlElement nhanvien = doc.CreateElement("nhanvien");
            XmlAttribute manv = doc.CreateAttribute("manv");
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
            nhanvien.AppendChild(hoten);
            nhanvien.AppendChild(tuoi);
            nhanvien.AppendChild(luong);
            diachi.AppendChild(xa);
            diachi.AppendChild(huyen);
            diachi.AppendChild(tinh);
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
                doc.Save(manv);
            }
            else
            {
                MessageBox.Show($"Mã nhân viên {manv} không hợp lệ!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void Update(NhanVien nv)
        {
            XmlNode node = root.SelectSingleNode($"nhanvien[@manv='{nv.MaNV}']");
            if (node != null)
            {
                var hoten = node.SelectSingleNode("hoten");
                var tuoi = node.SelectSingleNode("tuoi");
                var luong = node.SelectSingleNode("luong");
                var xa = node.SelectSingleNode("diachi/xa");
                var huyen = node.SelectSingleNode("diachi/huyen");
                var tinh = node.SelectSingleNode("diachi/tinh");
                var dienthoai = node.SelectSingleNode("dienthoai");

                hoten.InnerText = nv.HoTen;
                tuoi.InnerText = nv.Tuoi.ToString();
                luong.InnerText = nv.Luong.ToString();
                xa.InnerText = nv.Xa;
                huyen.InnerText = nv.Huyen;
                tinh.InnerText = nv.Tinh;
                dienthoai.InnerText = nv.DienThoai;
                doc.Save(filename);
            }
            else {
                MessageBox.Show($"Mã nhân viên {nv.MaNV} không hợp lệ!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public bool MaNVDaTonTai (string manv)
        {
            XmlNode node = root.SelectSingleNode($"nhanvien[@manv='{manv}']");
            if ( node != null )
            {
                return true;
            }
            return false;
        }
    }
}
