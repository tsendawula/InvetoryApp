Imports System.Data.SqlClient

Public Class Form1

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Me.TextBox1.Name = "Text"

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Me.TextBox4.Name = "TextBox4"
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Me.TextBox2.Name = "TextBox2"
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Me.TextBox3.Name = "TextBox3"
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If TextBox5.Text = Nothing Then
            TextBox5.Text = Me.TextBox5.Name = "TextBox5"
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try
            TextBox5.Text = ((TextBox1.Text * TextBox2.Text) + ((TextBox2.Text * 1.5) * TextBox3.Text))

            TextBox6.Text = ((TextBox2.Text * 1.5) * TextBox3.Text)
            TextBox7.Text = (TextBox1.Text * TextBox2.Text)


            MsgBox("YOUR WEEKLY GROSS PAYMENT: " + TextBox5.Text, MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Try

            Dim conn_ As New SqlConnection("Initial Catalog=Payroll;" & "Data Source=desktop-bdg6b00\sqlexpress;Integrated Security=SSPI;")
            conn_.Open()
            Dim command As New SqlCommand("INSERT INTO Employee (EmployeeID, EmployeeFN, EmployeeLN, Employee_Hrs_worked, Employee_Hourly_Wage, Employee_Overtime, Employee_Total_Overtime_allowances, Employee_Total_Wages, Employee_Weekly_Gross,Date_Entry_Made) VALUES (@EmployeeID,@EmployeeFN,@EmployeeLN,@Employee_Hrs_worked,@Employee_Hourly_Wage,@Employee_Overtime,@Employee_Total_Overtime_allowances,@Employee_Total_Wages,@Employee_Weekly_Gross,@Date_Entry_Made);" + "select   getdate(),getdate(),COALESCE(' + @id + ','''');",
                              conn_)
            command.Parameters.AddWithValue("@EmployeeID", TextBox9.Text)
            command.Parameters.AddWithValue("@EmployeeFN", TextBox4.Text)
            command.Parameters.AddWithValue("@EmployeeLN", TextBox8.Text)
            command.Parameters.AddWithValue("@Employee_Hrs_worked", TextBox1.Text)
            command.Parameters.AddWithValue("@Employee_Hourly_Wage", TextBox2.Text)
            command.Parameters.AddWithValue("@Employee_Overtime", TextBox3.Text)
            command.Parameters.AddWithValue("@Employee_Total_Overtime_allowances", TextBox6.Text)
            command.Parameters.AddWithValue("@Employee_Total_Wages", TextBox7.Text)
            command.Parameters.AddWithValue("@Employee_Weekly_Gross", TextBox5.Text)
            command.Parameters.AddWithValue("@Date_Entry_Made", TextBox10.Text)


            command.ExecuteNonQuery()
            MsgBox("EMPLOYEE PAYMENT SAVED.", MsgBoxStyle.Information)
            conn_.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        Me.TextBox8.Name = "TextBox8"
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

        Me.TextBox6.Name = "TextBox6"
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        If Me.TextBox2.Name <= 40 Then
            TextBox7.Name = TextBox1.Name * TextBox2.Name
        ElseIf
                Me.TextBox2.Name > 40 then

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
        TextBox3.Text = String.Empty
        TextBox4.Text = String.Empty
        TextBox5.Text = String.Empty
        TextBox6.Text = String.Empty
        TextBox7.Text = String.Empty
        TextBox8.Text = String.Empty

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged
        If TextBox10.Text = Nothing Then
            TextBox10.Text = DateTime.Now.ToString("yyyy/MM/dd HH: mm:ss")
        End If
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        If TextBox9.Text = Nothing Then
            TextBox9.Text = Me.TextBox9.Name = "TextBox9"
        End If
    End Sub
End Class
