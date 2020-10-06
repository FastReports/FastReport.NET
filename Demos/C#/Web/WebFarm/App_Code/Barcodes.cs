using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using FastReport;
using FastReport.Data;
using FastReport.Dialog;
using FastReport.Barcode;
using FastReport.Table;
using FastReport.Utils;

namespace FastReport
{
  public class Barcodes : Report
  {
    public FastReport.Report Report;
    public FastReport.Engine.ReportEngine Engine;
    public FastReport.Barcode.BarcodeObject Barcode19;
    public FastReport.Barcode.BarcodeObject Barcode20;
    public FastReport.Barcode.BarcodeObject Barcode21;
    public FastReport.Barcode.BarcodeObject Barcode22;
    public FastReport.Barcode.BarcodeObject Barcode23;
    public FastReport.Barcode.BarcodeObject Barcode24;
    public FastReport.Barcode.BarcodeObject Barcode25;
    public FastReport.Barcode.BarcodeObject Barcode26;
    public FastReport.Barcode.BarcodeObject Barcode27;
    public FastReport.Barcode.BarcodeObject Barcode28;
    public FastReport.Barcode.BarcodeObject Barcode29;
    public FastReport.Barcode.BarcodeObject Barcode30;
    public FastReport.Barcode.BarcodeObject Barcode31;
    public FastReport.Barcode.BarcodeObject Barcode32;
    public FastReport.Barcode.BarcodeObject Barcode33;
    public FastReport.Barcode.BarcodeObject Barcode34;
    public FastReport.Barcode.BarcodeObject Barcode35;
    public FastReport.Barcode.BarcodeObject Barcode36;
    public FastReport.Barcode.BarcodeObject Barcode37;
    public FastReport.ReportPage Page1;
    public FastReport.ReportTitleBand ReportTitle1;
    public FastReport.TextObject Text1;
    public FastReport.TextObject Text32;
    public FastReport.TextObject Text33;
    public FastReport.TextObject Text34;
    public FastReport.TextObject Text35;
    public FastReport.TextObject Text36;
    public FastReport.TextObject Text37;
    public FastReport.TextObject Text38;
    public FastReport.TextObject Text39;
    public FastReport.TextObject Text40;
    public FastReport.TextObject Text41;
    public FastReport.TextObject Text42;
    public FastReport.TextObject Text43;
    public FastReport.TextObject Text44;
    public FastReport.TextObject Text45;
    public FastReport.TextObject Text46;
    public FastReport.TextObject Text47;
    public FastReport.TextObject Text48;
    public FastReport.TextObject Text49;
    public FastReport.TextObject Text50;
    protected override object CalcExpression(string expression, Variant Value)
    {
      return null;
    }

    private void InitializeComponent()
    {
      string reportString = 
        "﻿<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Report TextQuality=\"Regular\" ReportInf" +
        "o.Description=\"This report demonstrates different barcode types:&#13;&#10;&#13;&" +
        "#10;- 2/5 barcodes (Interleaved, Industrial, Matrix);&#13;&#10;- Codabar;&#13;&#" +
        "10;- Code39 (Regular, Extended);&#13;&#10;- Code93 (Regular, Extended);&#13;&#10" +
        ";- Code128 (A, B, C charsets with autoencoding feature);&#13;&#10;- EAN8, EAN13;" +
        "&#13;&#10;- UPC-A, UPC-E (E0, E1 codes);&#13;&#10;- MSI;&#13;&#10;- PostNet;&#13" +
        ";&#10;- 2 or 5 digit supplement code for EAN/UPC barcodes;&#13;&#10;- PDF417;&#1" +
        "3;&#10;- Datamatrix.\" ReportInfo.Created=\"02/21/2008 20:44:59\" ReportInfo.Modifi" +
        "ed=\"11/11/2008 18:13:37\" ReportInfo.CreatorVersion=\"1.0.0.0\">\r\n  <Dictionary/>\r\n" +
        "  <ReportPage Name=\"Page1\">\r\n    <ReportTitleBand Name=\"ReportTitle1\" Width=\"718" +
        ".2\" Height=\"945\">\r\n      <TextObject Name=\"Text32\" Left=\"18.9\" Top=\"47.25\" Width" +
        "=\"170.1\" Height=\"151.2\" Border.Lines=\"Left, Right, Bottom\" Border.Color=\"Silver\"" +
        " Text=\"2/5 Interleaved\" Padding=\"2, 10, 2, 0\" HorzAlign=\"Center\" Font=\"Tahoma, 8" +
        "pt\"/>\r\n      <TextObject Name=\"Text33\" Left=\"189\" Top=\"47.25\" Width=\"170.1\" Heig";
      reportString += "ht=\"151.2\" Border.Lines=\"Left, Right, Bottom\" Border.Color=\"Silver\" Text=\"2/5 In" +
        "dustrial\" Padding=\"2, 10, 2, 0\" HorzAlign=\"Center\" Font=\"Tahoma, 8pt\"/>\r\n      <" +
        "TextObject Name=\"Text34\" Left=\"359.1\" Top=\"47.25\" Width=\"170.1\" Height=\"151.2\" B" +
        "order.Lines=\"Left, Right, Bottom\" Border.Color=\"Silver\" Text=\"2/5 Matrix\" Paddin" +
        "g=\"2, 10, 2, 0\" HorzAlign=\"Center\" Font=\"Tahoma, 8pt\"/>\r\n      <TextObject Name=" +
        "\"Text35\" Left=\"529.2\" Top=\"47.25\" Width=\"170.1\" Height=\"151.2\" Border.Lines=\"Lef" +
        "t, Right, Bottom\" Border.Color=\"Silver\" Text=\"Codabar\" Padding=\"2, 10, 2, 0\" Hor" +
        "zAlign=\"Center\" Font=\"Tahoma, 8pt\"/>\r\n      <TextObject Name=\"Text36\" Left=\"18.9" +
        "\" Top=\"198.45\" Width=\"170.1\" Height=\"151.2\" Border.Lines=\"All\" Border.Color=\"Sil" +
        "ver\" Text=\"Code39\" Padding=\"2, 10, 2, 0\" HorzAlign=\"Center\" Font=\"Tahoma, 8pt\"/>" +
        "\r\n      <TextObject Name=\"Text37\" Left=\"359.1\" Top=\"198.45\" Width=\"170.1\" Height" +
        "=\"151.2\" Border.Lines=\"All\" Border.Color=\"Silver\" Text=\"Code93\" Padding=\"2, 10, ";
      reportString += "2, 0\" HorzAlign=\"Center\" Font=\"Tahoma, 8pt\"/>\r\n      <TextObject Name=\"Text38\" L" +
        "eft=\"18.9\" Top=\"349.65\" Width=\"170.1\" Height=\"151.2\" Border.Lines=\"All\" Border.C" +
        "olor=\"Silver\" Text=\"Code128 (A, B, C), autoencode\" Padding=\"2, 10, 2, 0\" HorzAli" +
        "gn=\"Center\" Font=\"Tahoma, 8pt\"/>\r\n      <TextObject Name=\"Text39\" Left=\"189\" Top" +
        "=\"349.65\" Width=\"170.1\" Height=\"151.2\" Border.Lines=\"All\" Border.Color=\"Silver\" " +
        "Text=\"EAN8\" Padding=\"2, 10, 2, 0\" HorzAlign=\"Center\" Font=\"Tahoma, 8pt\"/>\r\n     " +
        " <TextObject Name=\"Text40\" Left=\"359.1\" Top=\"349.65\" Width=\"170.1\" Height=\"151.2" +
        "\" Border.Lines=\"All\" Border.Color=\"Silver\" Text=\"EAN13\" Padding=\"2, 10, 2, 0\" Ho" +
        "rzAlign=\"Center\" Font=\"Tahoma, 8pt\"/>\r\n      <TextObject Name=\"Text41\" Left=\"529" +
        ".2\" Top=\"349.65\" Width=\"170.1\" Height=\"151.2\" Border.Lines=\"All\" Border.Color=\"S" +
        "ilver\" Text=\"UPC-A\" Padding=\"2, 10, 2, 0\" HorzAlign=\"Center\" Font=\"Tahoma, 8pt\"/" +
        ">\r\n      <TextObject Name=\"Text42\" Left=\"18.9\" Top=\"500.85\" Width=\"170.1\" Height";
      reportString += "=\"151.2\" Border.Lines=\"All\" Border.Color=\"Silver\" Text=\"UPC-E (E0, E1)\" Padding=" +
        "\"2, 10, 2, 0\" HorzAlign=\"Center\" Font=\"Tahoma, 8pt\"/>\r\n      <TextObject Name=\"T" +
        "ext43\" Left=\"189\" Top=\"500.85\" Width=\"170.1\" Height=\"151.2\" Border.Lines=\"All\" B" +
        "order.Color=\"Silver\" Text=\"Supplement code (2 or 5 digits)\" Padding=\"2, 10, 2, 0" +
        "\" HorzAlign=\"Center\" Font=\"Tahoma, 8pt\"/>\r\n      <TextObject Name=\"Text44\" Left=" +
        "\"359.1\" Top=\"500.85\" Width=\"170.1\" Height=\"151.2\" Border.Lines=\"All\" Border.Colo" +
        "r=\"Silver\" Text=\"MSI\" Padding=\"2, 10, 2, 0\" HorzAlign=\"Center\" Font=\"Tahoma, 8pt" +
        "\"/>\r\n      <TextObject Name=\"Text45\" Left=\"529.2\" Top=\"500.85\" Width=\"170.1\" Hei" +
        "ght=\"151.2\" Border.Lines=\"All\" Border.Color=\"Silver\" Text=\"PostNet\" Padding=\"2, " +
        "10, 2, 0\" HorzAlign=\"Center\" Font=\"Tahoma, 8pt\"/>\r\n      <TextObject Name=\"Text4" +
        "6\" Left=\"18.9\" Top=\"727.65\" Width=\"170.1\" Height=\"151.2\" Border.Lines=\"Left, Rig" +
        "ht, Bottom\" Border.Color=\"Silver\" Text=\"PDF417 (text/numeric/binary)\" Padding=\"2";
      reportString += ", 10, 2, 0\" HorzAlign=\"Center\" Font=\"Tahoma, 8pt\"/>\r\n      <TextObject Name=\"Tex" +
        "t47\" Left=\"189\" Top=\"727.65\" Width=\"170.1\" Height=\"151.2\" Border.Lines=\"Left, Ri" +
        "ght, Bottom\" Border.Color=\"Silver\" Text=\"Datamatrix\" Padding=\"2, 10, 2, 0\" HorzA" +
        "lign=\"Center\" Font=\"Tahoma, 8pt\"/>\r\n      <BarcodeObject Name=\"Barcode19\" Left=\"" +
        "56.7\" Top=\"94.5\" Width=\"80\" Height=\"85.05\" Barcode=\"2/5 Interleaved\"/>\r\n      <B" +
        "arcodeObject Name=\"Barcode20\" Left=\"207.9\" Top=\"94.5\" Width=\"140\" Height=\"85.05\"" +
        " Fill.Color=\"White\" Barcode=\"2/5 Industrial\"/>\r\n      <BarcodeObject Name=\"Barco" +
        "de21\" Left=\"396.9\" Top=\"94.5\" Width=\"98.75\" Height=\"85.05\" Fill.Color=\"White\" Ba" +
        "rcode=\"2/5 Matrix\"/>\r\n      <BarcodeObject Name=\"Barcode22\" Left=\"548.1\" Top=\"94" +
        ".5\" Width=\"126.25\" Height=\"85.05\" Fill.Color=\"White\" Barcode=\"Codabar\"/>\r\n      " +
        "<BarcodeObject Name=\"Barcode23\" Left=\"28.35\" Top=\"245.7\" Width=\"145\" Height=\"85." +
        "05\" Fill.Color=\"White\" Text=\"123456\"/>\r\n      <BarcodeObject Name=\"Barcode24\" Le";
      reportString += "ft=\"378\" Top=\"245.7\" Width=\"136.25\" Height=\"85.05\" Fill.Color=\"White\" Barcode=\"C" +
        "ode93\"/>\r\n      <BarcodeObject Name=\"Barcode25\" Left=\"56.7\" Top=\"396.9\" Width=\"9" +
        "8.75\" Height=\"85.05\" Fill.Color=\"White\" Barcode=\"Code128\" Barcode.AutoEncode=\"tr" +
        "ue\"/>\r\n      <BarcodeObject Name=\"Barcode26\" Left=\"236.25\" Top=\"396.9\" Width=\"83" +
        ".75\" Height=\"85.05\" Fill.Color=\"White\" Barcode=\"EAN8\"/>\r\n      <BarcodeObject Na" +
        "me=\"Barcode27\" Left=\"378\" Top=\"396.9\" Width=\"128.75\" Height=\"85.05\" Fill.Color=\"" +
        "White\" Text=\"1234567890123\" Barcode=\"EAN13\"/>\r\n      <BarcodeObject Name=\"Barcod" +
        "e28\" Left=\"548.1\" Top=\"396.9\" Width=\"138.75\" Height=\"85.05\" Fill.Color=\"White\" T" +
        "ext=\"123456789012\" Barcode=\"UPC-A\"/>\r\n      <BarcodeObject Name=\"Barcode29\" Left" +
        "=\"66.15\" Top=\"548.1\" Width=\"83.75\" Height=\"85.05\" Fill.Color=\"White\" Text=\"12345" +
        "67\" Barcode=\"UPC-E0\"/>\r\n      <BarcodeObject Name=\"Barcode30\" Left=\"217.35\" Top=" +
        "\"548.1\" Width=\"25\" Height=\"56.7\" Fill.Color=\"White\" Barcode=\"Supplement 2\"/>\r\n  ";
      reportString += "    <BarcodeObject Name=\"Barcode31\" Left=\"274.05\" Top=\"548.1\" Width=\"58.75\" Heig" +
        "ht=\"56.7\" Fill.Color=\"White\" Barcode=\"Supplement 5\"/>\r\n      <BarcodeObject Name" +
        "=\"Barcode32\" Left=\"368.55\" Top=\"548.1\" Width=\"143.75\" Height=\"85.05\" Fill.Color=" +
        "\"White\" Barcode=\"MSI\"/>\r\n      <BarcodeObject Name=\"Barcode33\" Left=\"538.65\" Top" +
        "=\"548.1\" Width=\"155\" Height=\"85.05\" Fill.Color=\"White\" Barcode=\"PostNet\"/>\r\n    " +
        "  <BarcodeObject Name=\"Barcode34\" Left=\"66.15\" Top=\"774.9\" Width=\"86\" Height=\"83" +
        "\" Barcode=\"PDF417\" Barcode.AspectRatio=\"0.5\" Barcode.Columns=\"0\" Barcode.Rows=\"0" +
        "\" Barcode.CodePage=\"437\" Barcode.CompactionMode=\"Auto\" Barcode.ErrorCorrection=\"" +
        "Auto\" Barcode.PixelSize=\"1, 5\"/>\r\n      <BarcodeObject Name=\"Barcode35\" Left=\"23" +
        "6.25\" Top=\"774.9\" Width=\"72\" Height=\"72\" ShowText=\"false\" Barcode=\"Datamatrix\" B" +
        "arcode.SymbolSize=\"Size24x24\" Barcode.Encoding=\"Auto\" Barcode.CodePage=\"1252\" Ba" +
        "rcode.PixelSize=\"3\"/>\r\n      <TextObject Name=\"Text1\" Left=\"18.9\" Top=\"9.45\" Wid";
      reportString += "th=\"680.4\" Height=\"37.8\" Fill.Color=\"Orange\" Text=\"LINEAR BARCODES\" VertAlign=\"C" +
        "enter\" Font=\"Tahoma, 16pt\"/>\r\n      <TextObject Name=\"Text48\" Left=\"18.9\" Top=\"6" +
        "89.85\" Width=\"680.4\" Height=\"37.8\" Fill.Color=\"Orange\" Text=\"2D BARCODES\" VertAl" +
        "ign=\"Center\" Font=\"Tahoma, 16pt\"/>\r\n      <TextObject Name=\"Text49\" Left=\"529.2\"" +
        " Top=\"198.45\" Width=\"170.1\" Height=\"151.2\" Border.Lines=\"All\" Border.Color=\"Silv" +
        "er\" Text=\"Code93 Extended\" Padding=\"2, 10, 2, 0\" HorzAlign=\"Center\" Font=\"Tahoma" +
        ", 8pt\"/>\r\n      <BarcodeObject Name=\"Barcode36\" Left=\"548.1\" Top=\"245.7\" Width=\"" +
        "136.25\" Height=\"85.05\" Fill.Color=\"White\" Barcode=\"Code93 Extended\"/>\r\n      <Te" +
        "xtObject Name=\"Text50\" Left=\"189\" Top=\"198.45\" Width=\"170.1\" Height=\"151.2\" Bord" +
        "er.Lines=\"All\" Border.Color=\"Silver\" Text=\"Code39 Extended\" Padding=\"2, 10, 2, 0" +
        "\" HorzAlign=\"Center\" Font=\"Tahoma, 8pt\"/>\r\n      <BarcodeObject Name=\"Barcode37\"" +
        " Left=\"198.45\" Top=\"245.7\" Width=\"145\" Height=\"85.05\" Fill.Color=\"White\" Text=\"1";
      reportString += "23456\" Barcode=\"Code39 Extended\"/>\r\n    </ReportTitleBand>\r\n  </ReportPage>\r\n</R" +
        "eport>\r\n";
      LoadFromString(reportString);

      InternalInit();
    }

    public Barcodes()
    {
      InitializeComponent();
    }
  }
}
