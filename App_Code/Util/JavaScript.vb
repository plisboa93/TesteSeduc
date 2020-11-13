Public Module JavaScript

    Public Sub MsgBox(ByVal Mensagem As String, Optional ByVal CategoriaMensagem As eCategoriaMensagem = eCategoriaMensagem.ALERTA)
        Dim executingPage As Object = HttpContext.Current.Handler

        Select Case CategoriaMensagem
            Case eCategoriaMensagem.ALERTA
                ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType, "MensagemDiv", "document.getElementById('divAlerta').style.display='block';", True)
                ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType, "MensagemTexto", String.Format("jQuery('#spnAlerta').text('{0}');", Mensagem), True)
            Case eCategoriaMensagem.SUCESSO
                ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType, "MensagemDiv", "document.getElementById('divSucesso').style.display='block';", True)
                ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType, "MensagemTexto", String.Format("jQuery('#spnSucesso').text('{0}');", Mensagem), True)
            Case eCategoriaMensagem.ERRO
                ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType, "MensagemDiv", "document.getElementById('divErro').style.display='block';", True)
                ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType, "MensagemTexto", String.Format("jQuery('#spnErro').text('{0}');", Mensagem), True)
            Case eCategoriaMensagem.AVISO
                ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType, "MensagemDiv", "document.getElementById('divAviso').style.display='block';", True)
                ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType, "MensagemTexto", String.Format("jQuery('#spnAviso').text('{0}');", Mensagem), True)
            Case eCategoriaMensagem.AVISO_CLASSICO
                ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType, "mensagem", String.Format("alert('{0}');", Mensagem), True)
            Case eCategoriaMensagem.AVISO_CONFIRMACAO
                ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType, "MensagemDiv", "document.getElementById('divConfirmacao').style.display='block';", True)
                ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType, "MensagemTexto", String.Format("jQuery('#spnConfirmacao').text('{0}');", Mensagem), True)

                'Case 0
                '    ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType, "MensagemDiv", "document.getElementById('divAlerta').style.display='block';", True)
                '    ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType, "MensagemTexto", String.Format("jQuery('#spnAlerta').text('{0}');", Mensagem), True)
                'Case 1
                '    ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType, "MensagemDiv", "document.getElementById('divSucesso').style.display='block';", True)
                '    ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType, "MensagemTexto", String.Format("jQuery('#spnSucesso').text('{0}');", Mensagem), True)
                'Case 2
                '    ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType, "MensagemDiv", "document.getElementById('divErro').style.display='block';", True)
                '    ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType, "MensagemTexto", String.Format("jQuery('#spnErro').text('{0}');", Mensagem), True)
        End Select

    End Sub

    Public Sub MsgBox(ByVal Mensagem As String, ByVal Pagina As String)
        Dim executingPage As Object = HttpContext.Current.Handler
        ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType, "mensagem", String.Format("alert('{0}');", Mensagem) & String.Format("window.location='{0}';", Pagina), True)
    End Sub

    Public Enum eCategoriaMensagem As Short
        ALERTA = 0
        SUCESSO = 1
        ERRO = 2
        AVISO = 3
        AVISO_CLASSICO = 4
        AVISO_CONFIRMACAO = 5
    End Enum

    Public Enum eTipoMensagem As Short
        EXCLUIR_ERRO = 0
        EXCLUIR_SUCESSO = 1
        SALVAR_ERRO = 2
        SALVAR_SUCESSO = 3
        RESULTADO_VAZIO = 4
        PERMISSAO_NEGADA = 5
    End Enum

    Public Sub MsgBox(ByVal TipoMensagem As eTipoMensagem)
        Select Case TipoMensagem

            Case eTipoMensagem.SALVAR_SUCESSO
                MsgBox("As informa��es foram salvas!", eCategoriaMensagem.SUCESSO)

            Case eTipoMensagem.SALVAR_ERRO
                MsgBox("As informa��es n�o puderam ser salvas!", eCategoriaMensagem.ERRO)

            Case eTipoMensagem.EXCLUIR_SUCESSO
                MsgBox("As informa��es foram exclu�das.", eCategoriaMensagem.SUCESSO)

            Case eTipoMensagem.EXCLUIR_ERRO
                MsgBox("Verifique Informa��es Relacionadas antes de Excluir.", eCategoriaMensagem.ERRO)

            Case eTipoMensagem.RESULTADO_VAZIO
                MsgBox("Sua busca n�o retornou resultado!", eCategoriaMensagem.ALERTA)

            Case eTipoMensagem.PERMISSAO_NEGADA
                MsgBox("Voc� n�o tem permiss�o para esta opera��o!", eCategoriaMensagem.ALERTA)

        End Select
    End Sub

    Public Enum eTipoConfirmacao As Short
        NOVO = 0
        SALVAR = 1
        EXCLUIR = 2
        IMPRIMIR = 3
        VOLTAR = 4
        ENVIAR = 5
        APROVADO = 6
        NAO_APROVADO = 7
    End Enum

    Public Sub ExibirConfirmacao(ByVal Botao As Object, ByVal TipoConfirmacao As eTipoConfirmacao)
        Select Case TipoConfirmacao
            Case eTipoConfirmacao.NOVO
                ExibirConfirmacao(Botao, "Deseja limpar as informa��es da tela para inserir um novo registro?")

            Case eTipoConfirmacao.SALVAR
                ExibirConfirmacao(Botao, "Deseja salvar as informa��es da tela?")

            Case eTipoConfirmacao.EXCLUIR
                ExibirConfirmacao(Botao, "Deseja excluir as informa��es da tela?")

            Case eTipoConfirmacao.IMPRIMIR
                ExibirConfirmacao(Botao, "Deseja imprimir as informa��es da tela?")

            Case eTipoConfirmacao.VOLTAR
                ExibirConfirmacao(Botao, "Deseja voltar para a listagem das informa��es?")

            Case eTipoConfirmacao.APROVADO
                ExibirConfirmacao(Botao, "Deseja APROVAR informa��es?")

            Case eTipoConfirmacao.NAO_APROVADO
                ExibirConfirmacao(Botao, "Deseja N�O APROVAR informa��es?")

        End Select
    End Sub

    Public Sub ExibirConfirmacao(ByVal Botao As Button, ByVal Mensagem As String)
        'Botao.Attributes.Add("OnClick", String.Format("document.getElementById('divConfirmacao').style.display='block';document.getElementById('spnConfirmacao').innerText='{0}';return(false);", Mensagem))

        Botao.Attributes.Add("OnClick", "if (!confirm('" & Mensagem & "')) { return(false); } ")
        'Dim executingPage As Object = HttpContext.Current.Handler

        'ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType, "MensagemDiv", "document.getElementById('divConfirmacao').style.display='block';", True)
        'ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType, "MensagemTexto", String.Format("document.getElementById('spnAlerta').innerText='{0}';", Mensagem), True)
    End Sub

    Public Sub ExibirConfirmacao(ByVal Botao As Button, ByVal Mensagem As String, ByVal YesChoosed As String, ByVal NoChoosed As String)
        Botao.Attributes.Add("OnClick", "if (confirm('" & Mensagem & "')) { " & YesChoosed & " } else { " & NoChoosed & "} ")
    End Sub

    Public Sub DoPostBack()
        Dim executingPage As Object = HttpContext.Current.Handler
        ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType, "PostBack", "__doPostBack('', '');", True)
    End Sub

End Module
