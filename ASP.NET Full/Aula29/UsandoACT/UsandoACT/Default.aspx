<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UsandoACT.Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .tituloAccordion
        {
            border:dashed 2px black;
            background-color:Navy;
            color:White;
            font-weight:bold;
            width:250px;
            cursor:pointer;
        }
        .conteudoAccordion
        {
            border:solid 1px black;
            background:silver;
            color:Navy;
            width:250px;
            height:200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>

        <asp:Accordion ID="Accordion1" runat="server">
            <Panes>
                <asp:AccordionPane runat="server">
                    <Header>
                        <div class="tituloAccordion">
                            Painel 1
                        </div>
                    </Header>
                    <Content>
                        <div class="conteudoAccordion">
                            <h1>Painel 1</h1>
                        </div>
                    </Content>
                </asp:AccordionPane>

                <asp:AccordionPane ID="AccordionPane1" runat="server">
                    <Header>
                        <div class="tituloAccordion">
                            Painel 1
                        </div>
                    </Header>
                    <Content>
                        <div class="conteudoAccordion">
                            <h1>Painel 1</h1>
                        </div>
                    </Content>
                </asp:AccordionPane>

                <asp:AccordionPane ID="AccordionPane2" runat="server">
                    <Header>
                        <div class="tituloAccordion">
                            Painel 1
                        </div>
                    </Header>
                    <Content>
                        <div class="conteudoAccordion">
                            <h1>Painel 1</h1>
                        </div>
                    </Content>
                </asp:AccordionPane>

                <asp:AccordionPane ID="AccordionPane3" runat="server">
                    <Header>
                        <div class="tituloAccordion">
                            Painel 1
                        </div>
                    </Header>
                    <Content>
                        <div class="conteudoAccordion">
                            <h1>Painel 1</h1>
                        </div>
                    </Content>
                </asp:AccordionPane>
            </Panes>
        </asp:Accordion>
    </div>
    </form>
</body>
</html>
