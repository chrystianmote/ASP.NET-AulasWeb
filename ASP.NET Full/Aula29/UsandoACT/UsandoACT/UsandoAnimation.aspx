<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsandoAnimation.aspx.cs" Inherits="UsandoACT.UsandoAnimation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>

        <div id="divAnimada" runat="server" style="width:200px;height:200px;background-color:Silver;border:solid 2px Black;">
        </div>

        <asp:AnimationExtender 
            ID="AnimationExtender1" 
            runat="server"
            TargetControlID="divAnimada" >
            <Animations>
                <OnClick>
                    <Sequence>
                        <FadeOut Duration="0.5"/> 
                        <Pulse Duration="0.2"/>                                             
                        <FadeIn Duration="0.5"/>  
                        <Scale ScaleFactor="2" />
                    </Sequence>
                </OnClick>
            </Animations>
        </asp:AnimationExtender>
    </div>
    </form>
</body>
</html>
