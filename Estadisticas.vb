Imports System.IO

Public Class frmEstadisticas
    'variables
    Dim i As Integer = 0
    Dim datos(999) As Integer 'vector de 1000 posiciones para cargar los datos
    Dim archivo As String 'para guardar la ruta del archivo que queremos abrir
    Dim sr As StreamReader 'para recorrer el archivo seleccionado
    Dim longvector As Integer 'para guardar la longitud del archivo cargado

    'Cerrar el formulario al hacer click en el botón salir
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Application.Exit()
    End Sub

    Private Sub btnCargarDatos_Click(sender As Object, e As EventArgs) Handles btnCargarDatos.Click
        CargarDatos()
    End Sub

    Private Sub btnValidarDatos_Click(sender As Object, e As EventArgs) Handles btnValidarDatos.Click
        ValidarDatos()
    End Sub

    Private Sub btnAnalizarDatos_Click(sender As Object, e As EventArgs) Handles btnAnalizarDatos.Click
        AnalizarDatos()
    End Sub

#Region "Procedimientos"
    'procedimiento para cargar los datos
    Private Sub CargarDatos()
        Vaciartextbox()
        'OFDArchivo.ShowDialog() 'para abrir el cuadro de diálogo donde buscaremos el archivo
        'DialogResult.OK para comprobar que no se cancela el cuadro de dialogo
        If OFDArchivo.ShowDialog() = DialogResult.OK Then
            archivo = OFDArchivo.FileName ' para coger el nombre del archivo
            sr = New StreamReader(archivo)
            btnValidarDatos.Enabled = True 'Habilitar el botón de validar datos
            i = 0
            'carga los datos del fichero hasta 1000
            While Not sr.EndOfStream And i < 1000
                'comprobar que los datos que se cargan del fichero tienen el formato correcto
                Try
                    datos(i) = Integer.Parse(sr.ReadLine) 'sr.ReadLine() para leer línea por línea
                    txtCargaDatos.Text = txtCargaDatos.Text & datos(i) & vbCrLf
                Catch ex As Exception
                    btnValidarDatos.Enabled = False
                    MessageBox.Show("El archivo contiene datos con formato incorrecto. Sólo números enteros", "Formato incorrecto")
                End Try
                i += 1

            End While
            longvector = i - 1

            sr.Close() 'cerrar el archivo
            OFDArchivo.FileName = "" 'vaciar el nombre del archivo
        Else
            'si se cancela no hace nada
            Exit Sub

        End If
    End Sub

    'Procedimiento que valida los datos
    Private Sub ValidarDatos()
        'variables
        Dim correcto As Boolean = True
        btnAnalizarDatos.Enabled = True 'Habilitar el botón de analizar datos

        'comprobar que los datos cargados están entre 0 y 100
        For i = 0 To longvector And correcto
            If datos(i) < 0 Or datos(i) > 100 Then
                correcto = False
            End If
        Next
        If correcto Then
            MessageBox.Show("Los datos se han validado correctamente.")
        Else
            MessageBox.Show("Los datos introducidos no son válidos. Los números han de estar entre el 0 y el 100")
            btnAnalizarDatos.Enabled = False
        End If

    End Sub

    'procedimiento para analizar los datos
    Private Sub AnalizarDatos()
        For i = 0 To longvector
            If datos(i) >= 0 And datos(i) <= 10 Then
                txtDe0a10.Text = txtDe0a10.Text & datos(i) & ", "
            ElseIf datos(i) >= 11 And datos(i) <= 20 Then
                txtDe11a20.Text = txtDe11a20.Text & datos(i) & ", "
            ElseIf datos(i) >= 21 And datos(i) <= 30 Then
                txtDe21a30.Text = txtDe21a30.Text & datos(i) & ", "
            ElseIf datos(i) >= 31 And datos(i) <= 40 Then
                txtDe31a40.Text = txtDe31a40.Text & datos(i) & ", "
            ElseIf datos(i) >= 41 And datos(i) <= 50 Then
                txtDe41a50.Text = txtDe41a50.Text & datos(i) & ", "
            ElseIf datos(i) >= 51 And datos(i) <= 60 Then
                txtDe51a60.Text = txtDe51a60.Text & datos(i) & ", "
            ElseIf datos(i) >= 61 And datos(i) <= 70 Then
                txtDe61a70.Text = txtDe61a70.Text & datos(i) & ", "
            ElseIf datos(i) >= 71 And datos(i) <= 80 Then
                txtDe71a80.Text = txtDe71a80.Text & datos(i) & ", "
            ElseIf datos(i) >= 81 And datos(i) <= 90 Then
                txtDe81a90.Text = txtDe81a90.Text & datos(i) & ", "
            ElseIf datos(i) >= 91 And datos(i) <= 100 Then
                txtDe91a100.Text = txtDe91a100.Text & datos(i) & ", "
            End If
        Next
        QuitarUltimacoma()
        btnValidarDatos.Enabled = False
        btnAnalizarDatos.Enabled = False
    End Sub
    'procedimiento para quitar la última coma
    Private Sub QuitarUltimacoma()
        txtDe0a10.Text = txtDe0a10.Text.Remove(txtDe0a10.Text.LastIndexOf(","))
        txtDe11a20.Text = txtDe11a20.Text.Remove(txtDe11a20.Text.LastIndexOf(","))
        txtDe21a30.Text = txtDe21a30.Text.Remove(txtDe21a30.Text.LastIndexOf(","))
        txtDe31a40.Text = txtDe31a40.Text.Remove(txtDe31a40.Text.LastIndexOf(","))
        txtDe41a50.Text = txtDe41a50.Text.Remove(txtDe41a50.Text.LastIndexOf(","))
        txtDe51a60.Text = txtDe51a60.Text.Remove(txtDe51a60.Text.LastIndexOf(","))
        txtDe61a70.Text = txtDe61a70.Text.Remove(txtDe61a70.Text.LastIndexOf(","))
        txtDe71a80.Text = txtDe71a80.Text.Remove(txtDe71a80.Text.LastIndexOf(","))
        txtDe81a90.Text = txtDe81a90.Text.Remove(txtDe81a90.Text.LastIndexOf(","))
        txtDe91a100.Text = txtDe91a100.Text.Remove(txtDe91a100.Text.LastIndexOf(","))
    End Sub
    'procedimiento para vaciar los cuadros de texto
    Private Sub Vaciartextbox()
        txtCargaDatos.Clear()
        txtDe0a10.Clear()
        txtDe11a20.Clear()
        txtDe21a30.Clear()
        txtDe31a40.Clear()
        txtDe41a50.Clear()
        txtDe51a60.Clear()
        txtDe61a70.Clear()
        txtDe71a80.Clear()
        txtDe81a90.Clear()
        txtDe91a100.Clear()
    End Sub
#End Region



End Class
