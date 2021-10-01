Imports System.Data.SQLite
Public Class Form1
    Dim newMarche As Boolean
    Dim updateMarche As Boolean
    Private dbPath As String = Application.StartupPath & "\db101.db"
    Private cnString As String = "Data Source=" & dbPath & ";Version=3;New=False;Compress=True;"
    Private cn As New SQLiteConnection(cnString)
    Private Sub Empty3DGV()
        cn.Open()
        Dim cmd2 As New SQLiteCommand("SELECT osae FROM osae WHERE id_marche = 'aTbwc'", cn)
        Dim dr2 As SQLiteDataReader = cmd2.ExecuteReader()
        Dim t2 As New DataTable
        t2.Load(dr2)
        dr2.Close()
        DGV2.DataSource = t2
        '-----------------
        Dim cmd3 As New SQLiteCommand("SELECT osre FROM osre WHERE id_marche = 'aTbwc'", cn)
        Dim dr3 As SQLiteDataReader = cmd3.ExecuteReader()
        Dim t3 As New DataTable
        t3.Load(dr3)
        dr3.Close()
        DGV3.DataSource = t3
        '-----------------
        Dim cmd4 As New SQLiteCommand("SELECT nbJrArr FROM nbJrArr WHERE id_marche = 'aTbwc'", cn)
        Dim dr4 As SQLiteDataReader = cmd4.ExecuteReader()
        Dim t4 As New DataTable
        t4.Load(dr4)
        dr4.Close()
        DGV4.DataSource = t4
        cn.Close()
    End Sub
    Private Sub rdonly()
        TextBox1.ReadOnly = True
        TextBox2.ReadOnly = True
        TextBox3.ReadOnly = True
        TextBox4.ReadOnly = True
        TextBox5.ReadOnly = True
        TextBox6.ReadOnly = True
        TextBox7.ReadOnly = True
        TextBox8.ReadOnly = True
        TextBox9.ReadOnly = True
        TextBox10.ReadOnly = True
        TextBox11.ReadOnly = True
        TextBox12.ReadOnly = True
        DGV2.ReadOnly = True
        DGV3.ReadOnly = True
        DGV4.ReadOnly = True
    End Sub
    Private Sub wrt()
        TextBox2.ReadOnly = False
        TextBox3.ReadOnly = False
        TextBox4.ReadOnly = False
        TextBox5.ReadOnly = False
        TextBox6.ReadOnly = False
        TextBox7.ReadOnly = False
        TextBox8.ReadOnly = False
        TextBox9.ReadOnly = False
        TextBox10.ReadOnly = False
        TextBox11.ReadOnly = False
        TextBox12.ReadOnly = False
        DGV2.ReadOnly = False
        DGV3.ReadOnly = False
        DGV4.ReadOnly = False
    End Sub
    Private Sub disabButt()
        newOSAE.Enabled = False
        newOSRE.Enabled = False
        newNbJrArr.Enabled = False
    End Sub
    Private Sub enabButt()
        newOSAE.Enabled = True
        newOSRE.Enabled = True
        newNbJrArr.Enabled = True
    End Sub
    Private Sub refrData()
        rdonly()
        saveButt.Enabled = False
        disabButt()
        rempTxtBxFirstLine()
        remplirDGV()
        rempl3DGV()
    End Sub
    Private Sub viderTextBox()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
    End Sub
    Private Sub rempTxtBxFirstLine()
        cn.Open()
        Dim cmd As New SQLiteCommand("SELECT * FROM marche ORDER BY numMarche LIMIT 1", cn)
        Dim dr As SQLiteDataReader = cmd.ExecuteReader()
        While dr.Read
            TextBox1.Text = dr.GetString(0).ToString
            TextBox2.Text = dr.GetString(1).ToString
            TextBox3.Text = dr.GetString(2).ToString
            TextBox4.Text = dr.GetInt64(3).ToString
            TextBox5.Text = dr.GetDouble(4).ToString
            TextBox6.Text = CDate(dr.GetString(5))
            TextBox7.Text = DateAdd("d", CInt(TextBox4.Text), TextBox6.Text)
            TextBox8.Text = dr.GetInt64(7).ToString
            TextBox9.Text = DateAdd("d", CInt(TextBox8.Text), TextBox7.Text)
            TextBox10.Text = dr.GetDouble(9).ToString
            TextBox11.Text = Format(Val(TextBox10.Text) / Val(TextBox5.Text) * 100, "00.00")
            TextBox12.Text = dr.GetString(11).ToString
        End While
        cn.Close()
    End Sub
    Private Sub remplirDGV()
        cn.Open()
        Dim cmd As New SQLiteCommand("SELECT * FROM marche ORDER BY numMarche", cn)
        Dim dr As SQLiteDataReader = cmd.ExecuteReader()
        Dim t As New DataTable
        t.Load(dr)
        dr.Close()
        DGV1.DataSource = t
        cn.Close()
    End Sub
    Private Sub rempl3DGV()
        cn.Open()
        Dim cmd2 As New SQLiteCommand("SELECT osae FROM osae WHERE id_marche = '" & TextBox1.Text & "'", cn)
        Dim dr2 As SQLiteDataReader = cmd2.ExecuteReader()
        Dim t2 As New DataTable
        t2.Load(dr2)
        dr2.Close()
        DGV2.DataSource = t2
        '-----------------
        Dim cmd3 As New SQLiteCommand("SELECT osre FROM osre WHERE id_marche = '" & TextBox1.Text & "'", cn)
        Dim dr3 As SQLiteDataReader = cmd3.ExecuteReader()
        Dim t3 As New DataTable
        t3.Load(dr3)
        dr3.Close()
        DGV3.DataSource = t3
        '-----------------
        Dim cmd4 As New SQLiteCommand("SELECT nbJrArr FROM nbJrArr WHERE id_marche = '" & TextBox1.Text & "'", cn)
        Dim dr4 As SQLiteDataReader = cmd4.ExecuteReader()
        Dim t4 As New DataTable
        t4.Load(dr4)
        dr4.Close()
        DGV4.DataSource = t4
        cn.Close()
    End Sub
    Private Sub newButt_Click(sender As Object, e As EventArgs) Handles newButt.Click
        TextBox1.ReadOnly = False
        wrt()
        updateMarche = False
        newMarche = True
        viderTextBox()
        Empty3DGV()
        enabButt()
        saveButt.Enabled = True
        updateButt.Enabled = False
        DeletButt.Enabled = False

        TextBox7.ReadOnly = True
        TextBox8.ReadOnly = True
        TextBox9.ReadOnly = True
        TextBox11.ReadOnly = True


    End Sub
    Private Sub saveButt_Click(sender As Object, e As EventArgs) Handles saveButt.Click
        Try
            cn.Open()
            Dim totJrs As Integer = 0
            Dim cmd9 As New SQLiteCommand("SELECT nbJrArr FROM nbJrArr WHERE id_marche = '" & TextBox1.Text & "'", cn)
            Dim dr4 As SQLiteDataReader = cmd9.ExecuteReader()
            While dr4.Read
                totJrs = totJrs + dr4.GetInt32(0)
            End While
            cn.Close()
            TextBox7.Text = DateAdd("d", CInt(TextBox4.Text), TextBox6.Text)
            TextBox8.Text = totJrs
            TextBox9.Text = DateAdd("d", CInt(TextBox8.Text), TextBox7.Text)
            TextBox11.Text = (Val(TextBox10.Text) / Val(TextBox5.Text)) * 100
            If newMarche Then
                Using cn1 As New SQLiteConnection(cnString)
                    cn1.Open()
                    Dim insrt1 As String = "INSERT INTO marche VALUES(@numMarche, @liaison, @titulaire, @delai, @cout, @osce, @finDelTh, @totJrArr, @finDelcmptArr, @paimEff, @avcmtcmpt, @observ)"
                    Dim cmd1 As New SQLiteCommand(insrt1, cn1)
                    cmd1.Parameters.AddWithValue("@numMarche", TextBox1.Text)
                    cmd1.Parameters.AddWithValue("@liaison", TextBox2.Text)
                    cmd1.Parameters.AddWithValue("@titulaire", TextBox3.Text)
                    cmd1.Parameters.AddWithValue("@delai", CInt(TextBox4.Text))
                    cmd1.Parameters.AddWithValue("@cout", Val(TextBox5.Text))
                    cmd1.Parameters.AddWithValue("@osce", CDate(TextBox6.Text))
                    cmd1.Parameters.AddWithValue("@finDelTh", CDate(TextBox7.Text))
                    cmd1.Parameters.AddWithValue("@totJrArr", CInt(TextBox8.Text))
                    cmd1.Parameters.AddWithValue("@finDelcmptArr", CDate(TextBox9.Text))
                    cmd1.Parameters.AddWithValue("@paimEff", Val(TextBox10.Text))
                    cmd1.Parameters.AddWithValue("@avcmtcmpt", Val(TextBox11.Text))
                    cmd1.Parameters.AddWithValue("@observ", TextBox12.Text)
                    cmd1.ExecuteNonQuery()
                    cn1.Close()
                End Using

            ElseIf updateMarche Then
                Using cn2 As New SQLiteConnection(cnString)
                    cn2.Open()
                    Dim insrt2 As String = "update marche set liaison = @liaison, titulaire = @titulaire, delai = @delai, cout = @cout, osce = @osce, finDelTh = @finDelTh, totJrArr = @totJrArr, finDelcmptArr = @finDelcmptArr, paimEff = @paimEff, avcmtcmpt = @avcmtcmpt, observ = @observ where numMarche = @numMarche"
                    Dim cmd2 As New SQLiteCommand(insrt2, cn2)
                    cmd2.Parameters.AddWithValue("@numMarche", TextBox1.Text)
                    cmd2.Parameters.AddWithValue("@liaison", TextBox2.Text)
                    cmd2.Parameters.AddWithValue("@titulaire", TextBox3.Text)
                    cmd2.Parameters.AddWithValue("@delai", CInt(TextBox4.Text))
                    cmd2.Parameters.AddWithValue("@cout", Val(TextBox5.Text))
                    cmd2.Parameters.AddWithValue("@osce", CDate(TextBox6.Text))
                    cmd2.Parameters.AddWithValue("@finDelTh", CDate(TextBox7.Text))
                    cmd2.Parameters.AddWithValue("@totJrArr", CInt(TextBox8.Text))
                    cmd2.Parameters.AddWithValue("@finDelcmptArr", CDate(TextBox9.Text))
                    cmd2.Parameters.AddWithValue("@paimEff", Val(TextBox10.Text))
                    cmd2.Parameters.AddWithValue("@avcmtcmpt", Val(TextBox11.Text))
                    cmd2.Parameters.AddWithValue("@observ", TextBox12.Text)
                    cmd2.ExecuteNonQuery()
                    cn2.Close()
                End Using
            End If
            refrData()
            DeletButt.Enabled = True
            newButt.Enabled = True
            updateButt.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Entrez des valeurs corrects s'il vous plait", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DeletButt_Click(sender As Object, e As EventArgs) Handles DeletButt.Click
        cn.Open()
        Dim cmd1 As New SQLiteCommand("DELETE FROM osae WHERE id_marche = '" & TextBox1.Text & "'", cn)
        Dim cmd2 As New SQLiteCommand("DELETE FROM osre WHERE id_marche = '" & TextBox1.Text & "'", cn)
        Dim cmd3 As New SQLiteCommand("DELETE FROM nbJrArr WHERE id_marche = '" & TextBox1.Text & "'", cn)
        Dim cmd4 As New SQLiteCommand("DELETE FROM marche WHERE numMarche = '" & TextBox1.Text & "'", cn)
        cmd1.ExecuteNonQuery()
        cmd2.ExecuteNonQuery()
        cmd3.ExecuteNonQuery()
        cmd4.ExecuteNonQuery()
        cn.Close()
        refrData()

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refrData()
    End Sub
    Private Sub extButt_Click(sender As Object, e As EventArgs) Handles extButt.Click
        If MessageBox.Show("Voullez-vous vraiment quitter?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            End
        End If
    End Sub
    Private Sub updateButt_Click(sender As Object, e As EventArgs) Handles updateButt.Click
        wrt()
        saveButt.Enabled = True
        newButt.Enabled = False
        DeletButt.Enabled = False
        enabButt()
        TextBox7.ReadOnly = True
        TextBox8.ReadOnly = True
        TextBox9.ReadOnly = True
        TextBox11.ReadOnly = True
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox11.Text = ""
        updateMarche = True
        newMarche = False
    End Sub
    Private Sub DGV1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV1.CellClick
        Dim n As Integer = e.RowIndex
        Dim totJrs As Integer = 0
        Dim selecRow As DataGridViewRow
        selecRow = DGV1.Rows(n)
        TextBox1.Text = selecRow.Cells(0).Value.ToString
        TextBox2.Text = selecRow.Cells(1).Value.ToString
        TextBox3.Text = selecRow.Cells(2).Value.ToString
        TextBox4.Text = selecRow.Cells(3).Value.ToString
        TextBox5.Text = selecRow.Cells(4).Value.ToString
        TextBox6.Text = CDate(selecRow.Cells(5).Value.ToString)
        TextBox7.Text = DateAdd("d", CInt(TextBox4.Text), TextBox6.Text)
        rempl3DGV()
        cn.Open()
        Dim cmd4 As New SQLiteCommand("SELECT nbJrArr FROM nbJrArr WHERE id_marche = '" & TextBox1.Text & "'", cn)
        Dim dr4 As SQLiteDataReader = cmd4.ExecuteReader()
        While dr4.Read
            totJrs = totJrs + dr4.GetInt32(0)
        End While
        cn.Close()
        TextBox8.Text = totJrs
        TextBox9.Text = DateAdd("d", CInt(TextBox8.Text), TextBox7.Text)
        TextBox10.Text = selecRow.Cells(9).Value.ToString
        TextBox11.Text = Format(Val(TextBox10.Text) / Val(TextBox5.Text) * 100, "00.00")
        TextBox12.Text = selecRow.Cells(11).Value.ToString
        saveButt.Enabled = False
        DeletButt.Enabled = True
        updateButt.Enabled = True
    End Sub

    Private Sub newOSAE_Click(sender As Object, e As EventArgs) Handles newOSAE.Click
        Try
            Dim s As String = InputBox("Format de saisie: (aaaa-mm-jj) ou (aaaa/mm/jj)", "Entrez un nouveau OSAE")
            Using cn2 As New SQLiteConnection(cnString)
                cn2.Open()
                Dim insrt2 As String = "insert into osae values(@osae, @mar)"
                Dim cmd202 As New SQLiteCommand(insrt2, cn2)
                cmd202.Parameters.AddWithValue("@osae", CDate(s))
                cmd202.Parameters.AddWithValue("@mar", TextBox1.Text)
                cmd202.ExecuteNonQuery()
                '-----
                Dim cmd2 As New SQLiteCommand("SELECT osae FROM osae WHERE id_marche = '" & TextBox1.Text & "'", cn2)
                Dim dr2 As SQLiteDataReader = cmd2.ExecuteReader()
                Dim t2 As New DataTable
                t2.Load(dr2)
                dr2.Close()
                DGV2.DataSource = t2
                cn2.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Entrez des valeurs corrects s'il vous plait", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub newOSRE_Click(sender As Object, e As EventArgs) Handles newOSRE.Click
        Try
            Dim s As String = InputBox("Format de saisie: (aaaa-mm-jj) ou (aaaa/mm/jj)", "Entrez un nouveau OSRE")
            Using cn3 As New SQLiteConnection(cnString)
                cn3.Open()
                Dim insrt3 As String = "insert into osre values(@osre, @mar)"
                Dim cmd303 As New SQLiteCommand(insrt3, cn3)
                cmd303.Parameters.AddWithValue("@osre", CDate(s))
                cmd303.Parameters.AddWithValue("@mar", TextBox1.Text)
                cmd303.ExecuteNonQuery()
                '-----
                Dim cmd3 As New SQLiteCommand("Select osre FROM osre WHERE id_marche = '" & TextBox1.Text & "'", cn3)
                Dim dr3 As SQLiteDataReader = cmd3.ExecuteReader()
                Dim t3 As New DataTable
                t3.Load(dr3)
                dr3.Close()
                DGV3.DataSource = t3
                cn3.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Entrez des valeurs corrects s'il vous plait", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub newNbJrArr_Click(sender As Object, e As EventArgs) Handles newNbJrArr.Click
        Try
            Dim s As String = InputBox("", "Entrez un nouveau Nombre des jours d'arret")
            Using cn4 As New SQLiteConnection(cnString)
                cn4.Open()
                Dim insrt4 As String = "insert into nbJrArr values(@nbJrArr, @mar)"
                Dim cmd404 As New SQLiteCommand(insrt4, cn4)
                cmd404.Parameters.AddWithValue("@nbJrArr", CInt(s))
                cmd404.Parameters.AddWithValue("@mar", TextBox1.Text)
                cmd404.ExecuteNonQuery()
                Dim cmd4 As New SQLiteCommand("SELECT nbJrArr FROM nbJrArr WHERE id_marche = '" & TextBox1.Text & "'", cn4)
                Dim dr4 As SQLiteDataReader = cmd4.ExecuteReader()
                Dim t4 As New DataTable
                t4.Load(dr4)
                dr4.Close()
                DGV4.DataSource = t4
                cn4.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Entrez des valeurs corrects s'il vous plait", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub refrButt_Click(sender As Object, e As EventArgs) Handles refrButt.Click
        refrData()
        DeletButt.Enabled = True
        newButt.Enabled = True
        updateButt.Enabled = True
    End Sub
End Class