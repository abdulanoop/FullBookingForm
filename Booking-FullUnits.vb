Option Strict On
Option Explicit On
Imports System.Data.SqlClient
Imports System.Text

Public Class Booking_FullUnits
    Inherits BaseForm
    Dim flagNew As Boolean
    Dim flagEdit As Boolean
    Private ReadOnly myConDmm As String = My.Settings.YANBU_PALLETS_ConnectionString
    Private openConnection As New ClassConnection(myConDmm)
    Private isFormLoading As Boolean = True
    Private dtCustomers As DataTable
    Private dtSearchCustomers As DataTable

    Private Sub Booking_FullUnits_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Usr.B_Add = 1
        Usr.B_edit = 1
        Usr.B_Delete = 1
        Usr.Name = "Abdul"
        EnG_KeyBoard()
        clearAll()
        refreshVesselName()
        fillCombo()
        isFormLoading = False ' ✅ Prevents unwanted CheckedChanged triggers
    End Sub
    Private Sub Check1_CheckStateChanged(sender As Object, e As EventArgs) Handles Check1.CheckStateChanged
        If Check1.Checked Then
            txtEtaDay.Text = "00"
            txtEtaMonth.Text = "00"
            txtETAYear.Text = "00"
        Else
            txtEtaDay.Text = ""
            txtEtaMonth.Text = ""
            txtETAYear.Text = ""
        End If
    End Sub
    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        If Not flagEdit Then Exit Sub

        Dim checkUnits As Integer = getContainersCount()
        If Val(txtQty.Text) <= checkUnits Then
            MessageBox.Show("Please modify the Quantity and then try to add a single container. Presently there are " & checkUnits & " available for this Booking.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim getUnit As String = InputBox("Enter single Container Number you want to add for this Booking", "Add Single Container")
        If String.IsNullOrWhiteSpace(getUnit) Then
            MessageBox.Show("Cannot add blank unit. Action cancelled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not checkContainer(getUnit.Trim()) Then
            MessageBox.Show($"{getUnit.Trim()} container number you entered is not correct. Not saved.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If radioIN.Checked Then
            If checkInYardAndLine(getUnit.Trim(), Convert.ToInt16(ComboCustomer.SelectedValue)) Then
                MessageBox.Show($"{getUnit.Trim()} container is already inside the Yard. You cannot add this container.", "Already Present", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        Dim updateQuery As String = "UPDATE Full_BOOKING_NEW SET B_Qty = @Qty WHERE B_ID = @BID"
        Dim parameters As New List(Of SqlParameter) From {
        New SqlParameter("@Qty", txtQty.Text),
        New SqlParameter("@BID", txtB_ID.Text)
    }

        If openConnection.ExecuteScalarWithParameters(updateQuery, parameters) IsNot Nothing Then
            insertSingleContainer(getUnit.Trim().Substring(Math.Max(0, getUnit.Length - 11))) ' safely take rightmost 11 chars
            MessageBox.Show("Container added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            refreshData()
        End If
    End Sub
    Function checkContainer(ByVal txt As String) As Boolean
        txt = txt.Trim()
        If txt.Length <> 11 Then Return False

        ' First 4 characters must be letters
        For i As Integer = 0 To 3
            Dim ch = txt(i)
            If Not Char.IsLetter(ch) Then Return False
        Next

        ' Next 7 characters must be digits
        For i As Integer = 4 To 10
            Dim ch = txt(i)
            If Not Char.IsDigit(ch) Then Return False
        Next

        Return True
    End Function

    Private Sub refreshData()
        Dim query As String = "SELECT * FROM Full_BOOKING_NEW WHERE B_ID = @BID AND deleted = 0"
        Dim parameters As New List(Of SqlParameter) From {
        New SqlParameter("@BID", txtB_ID.Text)
    }

        Dim dt As DataTable = openConnection.GetDataTable(query, parameters)
        If dt.Rows.Count = 0 Then Exit Sub

        Dim row As DataRow = dt.Rows(0)

        ComboCustomer.SelectedValue = row("cust_id")

        If UCase(Trim(row("B_Type").ToString())) = "IN" Then
            radioIN.Checked = True
        Else
            radioOut.Checked = True
        End If

        txtB_ID.Text = row("B_ID").ToString()
        radioManual.Checked = True
        txtB_Number.Text = row("B_Number").ToString()

        comboVessel.Text = NullOrNot(row("VesselName"))
        txtB_Email.Text = NullOrNot(row("B_Sender"))
        ComboFromCity.Text = NullOrNot(row("fromCity"))
        ComboFromLoc.Text = NullOrNot(row("fromLoc"))
        ComboToCity.Text = NullOrNot(row("ToCity"))
        ComboToLoc.Text = NullOrNot(row("ToLoc"))

        txtRecitNo.Text = NullOrNot(row("RecitNo"))

        If Not IsDBNull(row("B_DTtm")) Then
            dtEmail.Value = Convert.ToDateTime(row("B_DTtm"))
        End If

        txtCntNo.Text = getContainers(row("B_ID"))
        txtQty.Text = row("B_Qty").ToString()

        If checkReadOutVessel Then
            comboVessel.Visible = True
            cmdAddVessel.Visible = True
        Else
            comboVessel.Visible = False
            cmdAddVessel.Visible = False
        End If
    End Sub
    Private Sub insertSingleContainer(ByVal cntno As String)
        Dim query As String = "
        INSERT INTO Full_BOOKING_UNITS_NEW (B_ID, cust_id, cntno, B_Type, C_IN, C_OUT)
        VALUES (@B_ID, @cust_id, @cntno, @B_Type, 0, 0)"

        Dim parameters As New List(Of SqlParameter) From {
        New SqlParameter("@B_ID", txtB_ID.Text),
        New SqlParameter("@cust_id", ComboCustomer.SelectedValue),
        New SqlParameter("@cntno", cntno.Trim().Substring(Math.Max(0, cntno.Trim().Length - 11))),
        New SqlParameter("@B_Type", If(radioIN.Checked, "IN", "OUT"))
    }

        openConnection.ExecuteSQLWithParameters(query, parameters)
    End Sub
    Private Function executeUpdateQuery(ByVal strSql As String) As Boolean
        Try
            openConnection.ExecuteSqlQuery(strSql)
            Return True
        Catch ex As Exception
            MessageBox.Show("Failed to execute update query: " & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private Function checkBookingUsed() As Boolean
        Dim query As String = "SELECT cntno FROM Full_Booking_Units_New WHERE B_ID = @BID AND (C_IN = 1 OR C_OUT = 1)"
        Dim parameters As New List(Of SqlParameter) From {
        New SqlParameter("@BID", txtB_ID.Text)
    }

        Dim dt As DataTable = openConnection.GetDataTable(query, parameters)
        Return dt.Rows.Count > 0
    End Function
    Private Sub cmdAddMore_Click(sender As Object, e As EventArgs) Handles cmdAddMore.Click
        If Not flagEdit Then Exit Sub

        Dim checkUnits As Integer = getContainersCount()
        If Val(txtQty.Text) <= checkUnits Then
            MessageBox.Show("Please modify the Quantity and then try to add a single container. Presently there are " & checkUnits & " available for this booking.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Frame3.Visible = True
        TxtEditCntno.Clear()
    End Sub
    Private Sub cmdAddVessel_Click(sender As Object, e As EventArgs) Handles cmdAddVessel.Click
        Dim vName As String = ""
        Dim cvName As String = ""

tryAgain:
        vName = InputBox("Enter the Vessel Name", "Add New Vessel").Trim()
        If vName = "" Then Exit Sub

        If checkHasRecords("SELECT 1 FROM Full_Vessel_List WHERE VesselName = @Name", New List(Of SqlParameter) From {
        New SqlParameter("@Name", vName)
    }) Then
            MessageBox.Show("This vessel already exists in the database. Please select it and proceed.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        cvName = InputBox("Re-enter the Vessel Name", "Confirm Vessel Name").Trim()
        If cvName = "" Then Exit Sub

        If Not vName.Equals(cvName, StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("Vessel name not matching. Please enter carefully again.", "Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            GoTo tryAgain
        End If

        openConnection.ExecuteSQLWithParameters("INSERT INTO Full_Vessel_List (VesselName) VALUES (@Name)", New List(Of SqlParameter) From {
        New SqlParameter("@Name", cvName)
    })

        refreshVesselName()
        comboVessel.Text = cvName
    End Sub
    Private Sub updateSqlQueryRaw(ByVal sqlStr As String)
        openConnection.ExecuteSqlQuery(sqlStr)
    End Sub
    Private Function checkHasRecords(query As String, Optional parameters As List(Of SqlParameter) = Nothing) As Boolean
        Dim dt As DataTable = openConnection.GetDataTable(query, parameters)
        Return dt.Rows.Count > 0
    End Function
    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        clearAll()
    End Sub
    Private Sub cmdCEdit_Click(sender As Object, e As EventArgs) Handles cmdCEdit.Click
        If Not flagEdit Then Exit Sub

        Dim checkUnits As Integer = getContainersCount()
        Dim getUnit As String = InputBox("Enter single Container Number you want to change", "Edit Single Container").Trim()

        If String.IsNullOrEmpty(getUnit) Then
            MessageBox.Show("Invalid input. Action cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not checkContainer(getUnit) Then
            MessageBox.Show($"{getUnit} container number you entered is not correct. Not saved.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If radioIN.Checked Then
            If checkInYardAndLine(getUnit, Convert.ToInt16(ComboCustomer.SelectedValue)) Then
                If MessageBox.Show($"{getUnit} container is already inside the Yard. Do you still want to edit this container?", "Confirm Container Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    MessageBox.Show("Action cancelled.")
                    Exit Sub
                End If
            End If
        End If

        Dim checkQuery As String = "SELECT cntno FROM Full_BOOKING_UNITS_NEW WHERE cntno = @OldUnit AND B_ID = @BID"
        Dim checkParams As New List(Of SqlParameter) From {
        New SqlParameter("@OldUnit", getUnit),
        New SqlParameter("@BID", txtB_ID.Text)
    }

        Dim dt As DataTable = openConnection.GetDataTable(checkQuery, checkParams)
        If dt.Rows.Count > 0 Then
            Dim getNewUnit As String = InputBox("Enter new Container Number you want to change to", "Edit Single Container").Trim()

            If String.IsNullOrEmpty(getNewUnit) Then
                MessageBox.Show("Invalid input. Action cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If Not checkContainer(getNewUnit) Then
                MessageBox.Show($"{getNewUnit} container number is not correct. Not saved.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim updateQuery As String = "
            UPDATE Full_BOOKING_UNITS_NEW 
            SET cntno = @NewUnit 
            WHERE cntno = @OldUnit AND B_ID = @BID"
            Dim updateParams As New List(Of SqlParameter) From {
            New SqlParameter("@NewUnit", getNewUnit),
            New SqlParameter("@OldUnit", getUnit),
            New SqlParameter("@BID", txtB_ID.Text)
        }

            openConnection.ExecuteSQLWithParameters(updateQuery, updateParams)

            ' Optional: Also update Full_Daily if needed (your logic placeholder)
            If radioIN.Checked Then
                ' If needed, call a method to update Full_Daily here
                ' updateDailyCntno(getUnit, getNewUnit)
            End If

            MessageBox.Show("Container updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            refreshData()
        End If
    End Sub
    Private Sub cmdChange_Click(sender As Object, e As EventArgs) Handles cmdChange.Click
        Dim confirmMessage As String
        Dim sqlQuery1 As String
        Dim sqlQuery2 As String

        If radioIN.Checked Then
            confirmMessage = "Are you sure you want to change Gate-In Booking to Gate-Out Booking?"
            sqlQuery1 = "UPDATE Full_Booking_New SET B_TYPE = 'OUT' WHERE B_ID = @BID"
            sqlQuery2 = "UPDATE Full_BOOKING_Units_NEW SET B_TYPE = 'OUT' WHERE B_ID = @BID"
        Else
            confirmMessage = "Are you sure you want to change Gate-Out Booking to Gate-In Booking?"
            sqlQuery1 = "UPDATE Full_Booking_New SET B_TYPE = 'IN' WHERE B_ID = @BID"
            sqlQuery2 = "UPDATE Full_BOOKING_Units_NEW SET B_TYPE = 'IN' WHERE B_ID = @BID"
        End If

        If MessageBox.Show(confirmMessage, "Confirm Changing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            MessageBox.Show("Action cancelled.")
            Exit Sub
        End If

        Dim parameters As New List(Of SqlParameter) From {
        New SqlParameter("@BID", txtB_ID.Text)
    }

        openConnection.ExecuteSQLWithParameters(sqlQuery1, parameters)
        openConnection.ExecuteSQLWithParameters(sqlQuery2, parameters)

        MessageBox.Show("Container type changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        refreshData()
        updateFGBooking()
    End Sub
    Private Sub CmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        If Not flagEdit Then Exit Sub

        Dim checkUnits As Integer = getContainersCount()
        Dim getUnit As String = InputBox("Enter single Container Number you want to delete from this booking", "Delete Single Container").Trim()

        If String.IsNullOrEmpty(getUnit) Then
            MessageBox.Show("Cannot delete blank unit. Action cancelled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not checkContainer(getUnit) Then
            MessageBox.Show($"{getUnit} container number is not correct. Action cancelled.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' ✅ Safety checks for IN bookings
        If radioIN.Checked Then
            Dim rcvdQuery As String = "
            SELECT 1 FROM Full_BOOKING_Units_NEW 
            WHERE Cntno = @Cntno AND B_ID = @BID AND Rcvd = 1"
            Dim inDateQuery As String = "
            SELECT 1 FROM Full_BOOKING_Units_NEW 
            WHERE Cntno = @Cntno AND B_ID = @BID AND (B_Indate IS NOT NULL AND B_Indate <> '')"

            Dim paramList As New List(Of SqlParameter) From {
            New SqlParameter("@Cntno", getUnit),
            New SqlParameter("@BID", txtB_ID.Text)
        }

            If openConnection.RecordExists(rcvdQuery, paramList) Then
                MessageBox.Show("You cannot delete this unit. It is already offloaded in the yard.", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If openConnection.RecordExists(inDateQuery, paramList) Then
                MessageBox.Show("You cannot delete this unit. It has already been received in the yard.", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If MessageBox.Show("Are you sure you want to delete this unit?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                Exit Sub
            End If

            ' ✅ Log deletion
            Dim deleteInsertQuery As String = "
            INSERT INTO Full_Booking_UnitsDeleted (BID, CntRefID, Deleted, DataSentToCloud, DataSentOn)
            VALUES (@BID, @CntRefID, 1, 0, NULL)"

            Dim containerID As Integer = getContainerID(getUnit, CInt(txtB_ID.Text))

            Dim deleteInsertParams As New List(Of SqlParameter) From {
            New SqlParameter("@BID", txtB_ID.Text),
            New SqlParameter("@CntRefID", containerID)
        }

            openConnection.ExecuteSQLWithParameters(deleteInsertQuery, deleteInsertParams)
        End If

        ' ✅ Delete the container from the original table
        Dim deleteQuery As String = "
        DELETE FROM Full_BOOKING_Units_NEW 
        WHERE Cntno = @Cntno AND B_ID = @BID"

        Dim deleteParams As New List(Of SqlParameter) From {
        New SqlParameter("@Cntno", getUnit),
        New SqlParameter("@BID", txtB_ID.Text)
    }

        openConnection.ExecuteSQLWithParameters(deleteQuery, deleteParams)

        MessageBox.Show("Container deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        refreshData()
        updateFGBooking()
    End Sub
    Private Function getContainerID(cntno As String, B_ID As Integer) As Integer
        Dim query As String = "
        SELECT ID FROM Full_BOOKING_Units_NEW 
        WHERE Cntno = @Cntno AND B_ID = @BID"

        Dim parameters As New List(Of SqlParameter) From {
        New SqlParameter("@Cntno", cntno),
        New SqlParameter("@BID", B_ID)
    }

        Dim result As Object = openConnection.GetSingleValueWithQuery(query, "ID", parameters)
        If result IsNot Nothing AndAlso IsNumeric(result) Then
            Return Convert.ToInt32(result)
        Else
            Return 0
        End If
    End Function
    Private Sub cmdEdit_Click(sender As Object, e As EventArgs) Handles cmdEdit.Click
        If Not ChkAccess(Usr.B_edit) Then Exit Sub

        If String.IsNullOrWhiteSpace(txtB_ID.Text) Then
            MessageBox.Show("Please select a booking to edit and then proceed.", "Missing Booking", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' UI Component Permissions
        radioIN.Enabled = True
        radioOut.Enabled = True
        ComboCustomer.Enabled = True
        radioAuto.Enabled = False
        radioManual.Enabled = True
        txtB_Email.Enabled = True
        txtRecitNo.Enabled = True
        dtEmail.Enabled = True
        txtQty.Enabled = True
        txtCntNo.Enabled = False
        txtB_Number.Enabled = True
        Combo1.Enabled = True
        Frame4.Enabled = True

        flagEdit = True
        flagNew = False

        cmdNew.Enabled = True
        cmdEdit.Enabled = False
        cmdSave.Enabled = True
        cmdCancel.Enabled = True
        cmdExit.Enabled = True

        Dim checkAC As Boolean = checkActivity(CInt(txtB_ID.Text))
        Label1.Visible = checkAC
        txtCntNo.Enabled = Not checkAC
        cmdAdd.Visible = True
        cmdAddMore.Visible = True
        cmdDelete.Visible = True
        cmdCEdit.Visible = True
        cmdChange.Visible = showHideSwapBtn(CInt(txtB_ID.Text))

        btnDeleteBooking.Enabled = False
        lblLabel.Visible = True
    End Sub
    Private Function checkActivity(B_ID As Integer) As Boolean
        Dim query As String

        If radioIN.Checked Then
            query = "
            SELECT B.B_ID, ISNULL(I.IN_C, 0) AS Completed
            FROM Full_BOOKING_NEW B
            LEFT JOIN (
                SELECT COUNT(*) AS IN_C, B_ID 
                FROM Full_BOOKING_UNITS_NEW 
                WHERE C_IN = 1 AND B_Type = 'IN' 
                GROUP BY B_ID
            ) I ON B.B_ID = I.B_ID
            WHERE B.B_ID = @BID"
        Else
            query = "
            SELECT B.B_ID, ISNULL(I.OUT_C, 0) AS Completed
            FROM Full_BOOKING_NEW B
            LEFT JOIN (
                SELECT COUNT(*) AS OUT_C, B_ID 
                FROM Full_BOOKING_UNITS_NEW 
                WHERE C_OUT = 1 AND B_Type = 'OUT' 
                GROUP BY B_ID
            ) I ON B.B_ID = I.B_ID
            WHERE B.B_ID = @BID"
        End If

        Dim parameters As New List(Of SqlParameter) From {
        New SqlParameter("@BID", B_ID)
    }

        Dim result As Object = openConnection.GetSingleValueWithQuery(query, "Completed", parameters)

        Return If(result IsNot Nothing AndAlso Val(result) >= 1, True, False)
    End Function
    Private Function showHideSwapBtn(B_ID As Integer) As Boolean
        Dim query As String

        If radioIN.Checked Then
            query = "
            SELECT B.B_ID, ISNULL(I.IN_C, 0) AS Completed
            FROM Full_BOOKING_NEW B
            LEFT JOIN (
                SELECT COUNT(*) AS IN_C, B_ID 
                FROM Full_BOOKING_UNITS_NEW 
                WHERE C_IN = 1 AND B_Type = 'IN' 
                GROUP BY B_ID
            ) I ON B.B_ID = I.B_ID
            WHERE B.B_ID = @BID"
        Else
            query = "
            SELECT B.B_ID, ISNULL(I.OUT_C, 0) AS Completed
            FROM Full_BOOKING_NEW B
            LEFT JOIN (
                SELECT COUNT(*) AS OUT_C, B_ID 
                FROM Full_BOOKING_UNITS_NEW 
                WHERE C_OUT = 1 AND B_Type = 'OUT' 
                GROUP BY B_ID
            ) I ON B.B_ID = I.B_ID
            WHERE B.B_ID = @BID"
        End If

        Dim parameters As New List(Of SqlParameter) From {
        New SqlParameter("@BID", B_ID)
    }

        Dim result As Object = openConnection.GetSingleValueWithQuery(query, "Completed", parameters)

        ' ✅ Button is only visible if no completed containers
        Return Not (result IsNot Nothing AndAlso Val(result) >= 1)
    End Function
    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click
        If Not ChkAccess(Usr.B_Add) Then Exit Sub

        ' Enable input controls
        Frame1.Enabled = True
        radioIN.Enabled = True
        radioOut.Enabled = True
        ComboCustomer.Enabled = True
        radioAuto.Enabled = True
        radioManual.Enabled = True
        txtB_Email.Enabled = True
        txtRecitNo.Enabled = True
        dtEmail.Enabled = True
        txtQty.Enabled = True
        txtCntNo.Enabled = True
        Combo1.Enabled = True
        Frame4.Enabled = True

        ' Reset selection states
        radioIN.Checked = False
        radioOut.Checked = False
        ComboCustomer.Text = ""

        ' Clear fields
        txtB_ID.Clear()
        txtB_Number.Clear()
        radioAuto.Checked = True
        txtB_Email.Clear()
        ComboFromCity.Text = ""
        ComboFromLoc.Text = ""
        ComboToCity.Text = ""
        ComboToLoc.Text = ""
        txtRecitNo.Clear()
        Combo1.Text = ""
        dtEmail.Value = Now
        txtQty.Clear()
        txtCntNo.Clear()

        ' Flags
        flagNew = True
        flagEdit = False

        ' Button states
        cmdNew.Enabled = False
        cmdEdit.Enabled = True
        cmdSave.Enabled = True
        cmdCancel.Enabled = True
        cmdExit.Enabled = True
        btnDeleteBooking.Enabled = False
        lblLabel.Visible = True
    End Sub
    Private Function getBookingID() As Integer
        Dim newID As Integer = 0
        Dim query As String = "SELECT BookingID FROM Full_SerialNumbersnew"

        Try
            ' Open a transaction-safe connection
            Using transConn = openConnection.GetNewConnection()
                Using trans As SqlTransaction = transConn.BeginTransaction()

                    Dim getCmd As New SqlCommand(query, transConn, trans)
                    Dim currentIdObj As Object = getCmd.ExecuteScalar()

                    If currentIdObj IsNot Nothing AndAlso IsNumeric(currentIdObj) Then
                        newID = Convert.ToInt32(currentIdObj) + 1

                        Dim updateCmd As New SqlCommand("UPDATE Full_SerialNumbersnew SET BookingID = @NewID", transConn, trans)
                        updateCmd.Parameters.AddWithValue("@NewID", newID)
                        updateCmd.ExecuteNonQuery()

                        trans.Commit()
                    Else
                        newID = 0
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error generating Booking ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return newID
    End Function
    ' 🚧 START OF CONVERTED cmdSave_Click (PARTIAL IMPLEMENTATION)
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim emailString As String = ""

        ' 1. Booking Type Validation
        If Not (radioIN.Checked Or radioOut.Checked) Then
            MessageBox.Show("Please choose booking type (IN/OUT). Not Saved", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 2. Booking Number Type Validation
        If Not (radioAuto.Checked Or radioManual.Checked) Then
            MessageBox.Show("Please select Booking Number mode (Auto/Manual). Not Saved", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 3. Vessel Name Required If Enabled
        If checkReadOutVessel AndAlso String.IsNullOrWhiteSpace(comboVessel.Text) Then
            MessageBox.Show("You must enter the Vessel Name for this booking", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 4. Duplicate Booking Check (if New)
        If flagNew Then
            Dim checkParams As New List(Of SqlParameter) From {
            New SqlParameter("@BNumber", txtB_Number.Text.Trim),
            New SqlParameter("@BType", If(radioIN.Checked, "IN", "OUT"))
        }
            If openConnection.RecordExists("SELECT B_ID FROM Full_Booking_New WHERE Deleted = 0 AND B_Number = @BNumber AND B_Type = @BType", checkParams) Then
                MessageBox.Show("Duplicate booking exists. Action cancelled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

        ' 5. Origin/Destination Validation
        If String.IsNullOrWhiteSpace(ComboFromCity.Text) OrElse
       String.IsNullOrWhiteSpace(ComboFromLoc.Text) OrElse
       String.IsNullOrWhiteSpace(ComboToCity.Text) OrElse
       String.IsNullOrWhiteSpace(ComboToLoc.Text) Then

            If MessageBox.Show("You have not specified origin/destination. Save anyway?", "Missing Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
        End If

        ' 6. ETA Check
        If String.IsNullOrWhiteSpace(txtEtaDay.Text) OrElse
       String.IsNullOrWhiteSpace(txtEtaMonth.Text) OrElse
       String.IsNullOrWhiteSpace(txtETAYear.Text) Then
            MessageBox.Show("Please enter the ETA for this unit.", "Missing ETA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 7. Shipping Line Check (for IN only)
        If radioIN.Checked AndAlso String.IsNullOrWhiteSpace(Combo1.Text) Then
            MessageBox.Show("Please enter the Shipping Line.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 8. Customer, Email, Recit, Qty, Container Count Check
        If String.IsNullOrWhiteSpace(ComboCustomer.Text) Then
            MessageBox.Show("Please choose a Customer.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If radioManual.Checked AndAlso String.IsNullOrWhiteSpace(txtB_Number.Text) Then
            MessageBox.Show("Please enter Booking Number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtB_Email.Text) Then
            MessageBox.Show("Please enter the Email Sender Name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If checkgetRecitNo AndAlso String.IsNullOrWhiteSpace(txtRecitNo.Text) Then
            MessageBox.Show("You must enter the Recit Number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRecitNo.Enabled = True
            txtRecitNo.Focus()
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtQty.Text) OrElse Val(txtQty.Text) = 0 Then
            MessageBox.Show("Please enter valid Quantity.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtCntNo.Text) Then
            MessageBox.Show("Please enter Container Numbers.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' ✅ Container Validation Loop
        Dim arr() As String = txtCntNo.Text.Split({vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
        Dim countItem As Integer = 0
        For Each line As String In arr
            If Not String.IsNullOrWhiteSpace(line) Then
                countItem += 1
                If Not checkContainer(line.Trim()) Then
                    MessageBox.Show($"{line.Trim()} container is invalid. Not Saved.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If
        Next

        If Val(txtQty.Text) <> countItem Then
            MessageBox.Show("Quantity and container count do not match.", "Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' ⚠️ Save logic continuation will be added next (flagNew/flagEdit logic, insert Full_Booking_New + Full_Booking_Units_New)
        ' ✅ Generate Booking ID if New
        Dim CHECKFORTYPE As String = If(radioIN.Checked, "IN", "OUT")

        If flagNew Then
            Dim duplicateParams As New List(Of SqlParameter) From {
            New SqlParameter("@BNumber", txtB_Number.Text.Trim()),
            New SqlParameter("@CustID", Convert.ToInt32(ComboCustomer.SelectedValue)),
            New SqlParameter("@BType", CHECKFORTYPE)
        }
            If openConnection.RecordExists("SELECT * FROM Full_BOOKING_NEW WHERE B_Number = @BNumber AND Cust_ID = @CustID AND Deleted <> 1 AND B_Type = @BType", duplicateParams) Then
                MessageBox.Show("This Booking already exists for this Customer. Cannot add again.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            txtB_ID.Text = getBookingID().ToString()

            If radioAuto.Checked Then
                txtB_Number.Text = If(radioIN.Checked, "WG_Full_IN_", "WG_Full_OUT_") & txtB_ID.Text
            End If
        End If

        ' ✅ Prevent duplicate B_ID
        If flagEdit AndAlso Not checkSameTXTB_ID Then
            MessageBox.Show("This booking exists already. Cannot add duplicate.", "Duplication Detected", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' ✅ Save to Full_BOOKING_NEW
        Dim bookingQuery As String
        Dim bookingParams As New List(Of SqlParameter) From {
        New SqlParameter("@B_Type", CHECKFORTYPE),
        New SqlParameter("@cust_id", ComboCustomer.SelectedValue),
        New SqlParameter("@B_ID", txtB_ID.Text),
        New SqlParameter("@B_Number", txtB_Number.Text),
        New SqlParameter("@VesselName", comboVessel.Text.Trim()),
        New SqlParameter("@B_Sender", txtB_Email.Text),
        New SqlParameter("@fromCity", ComboFromCity.Text.Trim()),
        New SqlParameter("@fromLoc", ComboFromLoc.Text.Trim()),
        New SqlParameter("@ToCity", ComboToCity.Text.Trim()),
        New SqlParameter("@ToLoc", ComboToLoc.Text.Trim()),
        New SqlParameter("@RecitNo", txtRecitNo.Text.Trim()),
        New SqlParameter("@B_DTtm", dtEmail.Value),
        New SqlParameter("@B_Qty", Convert.ToInt32(txtQty.Text)),
        New SqlParameter("@Completed", 0),
        New SqlParameter("@Deleted", 0),
        New SqlParameter("@CreatedBy", Usr.Name),
        New SqlParameter("@CreatedOn", DateTime.Now),
        New SqlParameter("@SlineName", Combo1.Text.Trim()),
        New SqlParameter("@txtETA", Date4INDEX(Attach_Date(txtEtaDay.Text, txtEtaMonth.Text, txtETAYear.Text))),
        New SqlParameter("@ToCloud", 0)
    }

        If flagNew Then
            bookingQuery = "INSERT INTO Full_BOOKING_NEW (B_Type, cust_id, B_ID, B_Number, VesselName, B_Sender, fromCity, fromLoc, ToCity, ToLoc, RecitNo, B_DTtm, B_Qty, Completed, Deleted, CreatedBy, CreatedOn, SlineName, txtETA, ToCloud) VALUES (@B_Type, @cust_id, @B_ID, @B_Number, @VesselName, @B_Sender, @fromCity, @fromLoc, @ToCity, @ToLoc, @RecitNo, @B_DTtm, @B_Qty, @Completed, @Deleted, @CreatedBy, @CreatedOn, @SlineName, @txtETA, @ToCloud)"
        Else
            bookingQuery = "UPDATE Full_BOOKING_NEW SET B_Type = @B_Type, cust_id = @cust_id, B_Number = @B_Number, VesselName = @VesselName, B_Sender = @B_Sender, fromCity = @fromCity, fromLoc = @fromLoc, ToCity = @ToCity, ToLoc = @ToLoc, RecitNo = @RecitNo, B_DTtm = @B_DTtm, B_Qty = @B_Qty, SlineName = @SlineName, txtETA = @txtETA WHERE B_ID = @B_ID"
        End If

        openConnection.ExecuteSQLWithParameters(bookingQuery, bookingParams)

        ' ✅ Prepare and Insert into Full_BOOKING_UNITS_NEW if New
        If flagNew Then
            emailString = "Dear All,<br><br>New " & If(radioIN.Checked, "Gatein", "Gateout") & " Booking Created: " & txtB_Number.Text & "<br>Customer Name: " & ComboCustomer.Text & "<br>Total Units: " & txtQty.Text & "<br>Containers:<br>"

            For Each line As String In arr
                If Not String.IsNullOrWhiteSpace(line) Then
                    Dim unitQuery As String = "INSERT INTO Full_BOOKING_UNITS_NEW (B_ID, cust_id, cntno, B_Type, C_IN, C_OUT) VALUES (@B_ID, @cust_id, @cntno, @B_Type, 0, 0)"
                    Dim unitParams As New List(Of SqlParameter) From {
                    New SqlParameter("@B_ID", txtB_ID.Text),
                    New SqlParameter("@cust_id", ComboCustomer.SelectedValue),
                    New SqlParameter("@cntno", line.Trim().Substring(Math.Max(0, line.Trim().Length - 11))),
                    New SqlParameter("@B_Type", CHECKFORTYPE)
                }
                    openConnection.ExecuteSQLWithParameters(unitQuery, unitParams)
                    emailString &= line.Trim() & "<br>"
                End If
            Next

            sendEmail(emailString)
            MessageBox.Show("Booking Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        ' ✅ Final UI Cleanup
        ComboCustomer.Enabled = False
        txtB_ID.Enabled = False
        txtB_Number.Enabled = False
        radioAuto.Enabled = False
        txtB_Email.Enabled = False
        txtRecitNo.Enabled = False
        dtEmail.Enabled = False
        txtQty.Enabled = False
        txtCntNo.Enabled = False
        Combo1.Enabled = False
        Frame4.Enabled = False

        flagNew = False
        flagEdit = False
        cmdNew.Enabled = True
        cmdEdit.Enabled = True
        cmdSave.Enabled = False
        btnDeleteBooking.Enabled = True
        Frame1.Enabled = True
        lblLabel.Visible = False

    End Sub
    Private Sub optEmpty_CheckedChanged(sender As Object, e As EventArgs) Handles optEmpty.CheckedChanged
        If optEmpty.Checked Then
            fillCombo()
        End If
    End Sub
    Private Sub optFull_CheckedChanged(sender As Object, e As EventArgs) Handles optFull.CheckedChanged
        If optFull.Checked Then
            fillCombo()
        End If
    End Sub
    Private Sub txtB_Number_Leave(sender As Object, e As EventArgs) Handles txtB_Number.Leave
        If flagNew Then
            Dim params As New List(Of SqlParameter) From {
            New SqlParameter("@BNumber", txtB_Number.Text.Trim()),
            New SqlParameter("@BType", If(radioIN.Checked, "IN", "OUT"))
        }

            If openConnection.RecordExists(
            "SELECT B_ID FROM Full_Booking_New WHERE Deleted = 0 AND B_Number = @BNumber AND B_Type = @BType",
            params) Then

                MessageBox.Show("This booking already exists for this customer. Please edit instead.", "Duplicate Booking", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
    End Sub
    Private Function checkSameTXTB_ID() As Boolean
        Dim params As New List(Of SqlParameter) From {
        New SqlParameter("@BID", txtB_ID.Text.Trim()),
        New SqlParameter("@BNumber", txtB_Number.Text.Trim()),
        New SqlParameter("@BType", If(radioIN.Checked, "IN", "OUT"))
    }

        Return openConnection.RecordExists(
        "SELECT B_ID FROM Full_Booking_New WHERE B_ID = @BID AND Deleted = 0 AND B_Number = @BNumber AND B_Type = @BType",
        params)
    End Function
    Private Sub txtETAYear_Leave(sender As Object, e As EventArgs) Handles txtETAYear.Leave
        If String.IsNullOrWhiteSpace(txtETAYear.Text) Then Exit Sub

        Dim yearValue As Integer
        If Integer.TryParse(txtETAYear.Text.Trim(), yearValue) Then
            If yearValue > 2050 OrElse yearValue <= 2019 Then
                MessageBox.Show("Invalid Year. Please correct.", "Year Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtETAYear.BackColor = Color.LightPink
                txtETAYear.Focus()
                Exit Sub
            End If
            txtETAYear.BackColor = Color.White
        Else
            MessageBox.Show("Year must be numeric.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtETAYear.BackColor = Color.LightPink
            txtETAYear.Focus()
        End If
    End Sub
    Private Sub sendEmail(ByVal emailString As String)
        Try
            Dim xTo As String = ""
            Dim xCC As String = ""

            ' ✅ Get email recipients for this customer
            Dim query As String = "
            SELECT sendas, Address 
            FROM autoreportemail_forFull 
            WHERE reptype = 1109 AND sline = @SLine"
            Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@SLine", ComboCustomer.SelectedValue)
        }

            Dim dt As DataTable = openConnection.GetDataTable(query, parameters)

            For Each row As DataRow In dt.Rows
                Dim sendAs = row("sendas").ToString().Trim().ToUpper()
                Dim email = row("Address").ToString().Trim()

                If sendAs = "TO" Then
                    xTo &= email & ";"
                ElseIf sendAs = "CC" Then
                    xCC &= email & ";"
                End If
            Next

            If String.IsNullOrWhiteSpace(xTo) Then
                ' No recipients found — do not send
                Exit Sub
            End If

            ' ✅ Prepare Outlook mail
            Dim oApp As New Microsoft.Office.Interop.Outlook.Application()
            Dim oMail As Microsoft.Office.Interop.Outlook.MailItem =
            CType(oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem), Microsoft.Office.Interop.Outlook.MailItem)

            ' ✅ Append signature
            emailString &= "<br><br>With Best Regards,<br>West Group Operations<br>Jeddah<br>" &
                       "Email: ter.operation@westgroup.com.sa<br>Tel: 012 2891044"

            ' ✅ Compose and send
            With oMail
                .To = xTo
                .CC = xCC
                .Subject = If(radioIN.Checked, "FC-New Gatein Booking Created. Booking No. ", "FC-New Gateout Booking Created. Booking No. ") & txtB_Number.Text
                .BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML
                .HTMLBody = emailString
                .Send()
            End With

        Catch ex As Exception
            MessageBox.Show("Failed to send email: " & ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function checkgetRecitNo() As Boolean
        Try
            Dim query As String
            If radioIN.Checked Then
                query = "SELECT RequestRecitGateinBooking AS mustRead FROM Full_Customers WHERE cust_ID = @CustID"
            Else
                query = "SELECT RequestRecitGateOutBooking AS mustRead FROM Full_Customers WHERE cust_ID = @CustID"
            End If

            Dim dt As DataTable = openConnection.GetDataTable(query, New List(Of SqlParameter) From {
            New SqlParameter("@CustID", ComboCustomer.SelectedValue)
        })

            If dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0)("mustRead")) Then
                Return Convert.ToBoolean(dt.Rows(0)("mustRead"))
            End If
        Catch ex As Exception
            MessageBox.Show("Error checking recit requirement: " & ex.Message)
        End Try
        Return False
    End Function
    Public Function executeQuery(strSql As String) As Boolean
        Try
            Dim dt As DataTable = openConnection.GetDataTable(strSql)
            Return dt IsNot Nothing AndAlso dt.Rows.Count > 0
        Catch ex As Exception
            MessageBox.Show("Execute query failed: " & ex.Message)
            Return False
        End Try
    End Function
    Private Sub ComboCustomer_Change(ByVal sender As Object, ByVal e As EventArgs) Handles ComboCustomer.SelectedIndexChanged
        If flagEdit OrElse flagNew Then
            If Not radioIN.Checked AndAlso Not radioOut.Checked Then
                MessageBox.Show("Please Select the Type of Booking")
                Exit Sub
            End If
        End If
    End Sub
    Private Sub ComboCustomer_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles ComboCustomer.Leave
        If checkReadOutVessel() Then
            comboVessel.Visible = True
            cmdAddVessel.Visible = True
        Else
            comboVessel.Visible = False
            cmdAddVessel.Visible = False
        End If
    End Sub
    Private Function checkReadOutVessel() As Boolean
        If Not radioOut.Checked Then Return False

        Try
            Dim query As String = "SELECT ReadVesselOut AS mustRead FROM Full_Customers WHERE cust_ID = @CustID"
            Dim dt As DataTable = openConnection.GetDataTable(query, New List(Of SqlParameter) From {
            New SqlParameter("@CustID", ComboCustomer.SelectedValue)
        })

            If dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0)("mustRead")) Then
                Return Convert.ToBoolean(dt.Rows(0)("mustRead"))
            End If
        Catch ex As Exception
            MessageBox.Show("Error reading vessel setting: " & ex.Message)
        End Try

        Return False
    End Function



    Private Sub btnDeleteBooking_Click(sender As Object, e As EventArgs) Handles btnDeleteBooking.Click
        If Not ChkAccess(Usr.B_Delete) Then Exit Sub

        If String.IsNullOrWhiteSpace(txtB_Number.Text) Then
            MessageBox.Show("Please Select a Booking Number to Delete and then Proceed")
            Exit Sub
        End If

        If flagNew OrElse flagEdit Then
            MessageBox.Show("You cannot delete a booking in New or Edit mode.")
            Exit Sub
        End If

        Dim containers() As String = txtCntNo.Text.Split({vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
        For Each container As String In containers
            Dim trimmedContainer = container.Trim()
            If Not String.IsNullOrEmpty(trimmedContainer) Then
                If Not checkContainer(trimmedContainer) Then
                    MessageBox.Show($"{trimmedContainer} container number you entered is not correct. Not Saved")
                    Exit Sub
                End If
            End If
        Next

        If MessageBox.Show("Are you sure you want to Delete this Booking?", "Confirm Booking Delete", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
            MessageBox.Show("Deletion Cancelled")
            Exit Sub
        End If

        If checkBookingUsed() Then
            MessageBox.Show("Already Units are present under this Booking. You cannot delete this booking. Action Cancelled")
            Exit Sub
        End If

        Dim query As String = "UPDATE Full_BOOKING_NEW SET Deleted = 1 WHERE B_ID = @B_ID"
        openConnection.ExecuteSQLWithParameters(query, New List(Of SqlParameter) From {
        New SqlParameter("@B_ID", Convert.ToInt32(txtB_ID.Text))
    })


        MessageBox.Show("Booking Deleted Successfully")
            refreshData()
            updateFGBooking()

    End Sub

    Private Sub btnEmailStatus_Click(sender As Object, e As EventArgs) Handles btnEmailStatus.Click
        If Not (radioIN.Checked OrElse radioOut.Checked) Then
            MessageBox.Show("Please Choose which Type of Booking and then Proceed.")
            Exit Sub
        End If

        If Not (radioAuto.Checked OrElse radioManual.Checked) Then
            MessageBox.Show("Please Enter/Select Booking Number and then Proceed.")
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(ComboCustomer.Text) Then
            MessageBox.Show("Please choose a Customer and then Proceed.")
            Exit Sub
        End If

        If radioManual.Checked AndAlso String.IsNullOrWhiteSpace(txtB_Number.Text) Then
            MessageBox.Show("Please choose/type a Booking Number and then Proceed.")
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtB_Email.Text) Then
            MessageBox.Show("Please enter the Email Sender Name and then Proceed.")
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtQty.Text) OrElse Val(txtQty.Text) = 0 Then
            MessageBox.Show("Please Enter the Quantity of Container For this Booking.")
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtCntNo.Text) Then
            MessageBox.Show("Please Enter the Container Numbers For this Booking.")
            Exit Sub
        End If

        ' ✅ FETCH RECIPIENT EMAILS
        Dim query As String = "SELECT * FROM autoreportemail_forFull WHERE reptype = 1108 AND sline = @CustomerID"
        Dim dtEmailRec As DataTable = openConnection.GetDataTable(query, New List(Of SqlParameter) From {
        New SqlParameter("@CustomerID", ComboCustomer.SelectedValue)
    })

        Dim xTo As String = ""
        Dim xCC As String = ""

        For Each row As DataRow In dtEmailRec.Rows
            Dim sendAs = row("sendas").ToString().Trim().ToUpper()
            Dim address = row("Address").ToString().Trim()
            If sendAs = "TO" Then
                xTo &= address & ";"
            ElseIf sendAs = "CC" Then
                xCC &= address & ";"
            End If
        Next

        If String.IsNullOrWhiteSpace(xTo) Then
            MessageBox.Show("No Recipients Exist. Mail Not Sent", "Booking Status")
            Exit Sub
        End If

        ' ✅ COMPOSE EMAIL BODY
        Dim xBody As String = "Dear All,<br>" &
        $"Status For Booking No: {txtB_Number.Text}<br>" &
        $"Customer Name: {ComboCustomer.Text}<br><br>" &
        $"Total Booking Units: {txtQty.Text}<br>"

        If radioIN.Checked Then
            xBody &= $"Total Units Gated In: {getBookingUnits()}<br>"
        Else
            xBody &= $"Total Units Gated Out: {getBookingUnits()}<br>"
        End If

        xBody &= "Containers: <br>" & getContainersList()
        xBody &= "<br>With Best Regards<br>West Group Operations<br>Jeddah<br>" &
             "Email: ter.operation@westgroup.com.sa<br>Tel: 012 2891044"

        ' ✅ SEND EMAIL
        Try
            Dim oApp As New Microsoft.Office.Interop.Outlook.Application()
            Dim oMail As Microsoft.Office.Interop.Outlook.MailItem =
            CType(oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem), Microsoft.Office.Interop.Outlook.MailItem)

            With oMail
                .To = xTo
                .CC = xCC
                .Subject = $"Booking Status of Booking No. {txtB_Number.Text}"
                .BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML
                .HTMLBody = xBody
                .Send()
            End With
        Catch ex As Exception
            MessageBox.Show("Failed to send email: " & ex.Message)
        End Try
    End Sub
    Function getBookingUnits() As Short
        Dim query As String
        If radioIN.Checked Then
            query = "SELECT COUNT(*) FROM FULL_BOOKING_UNITS_NEW WHERE C_IN = 1 AND B_TYPE = 'IN' AND B_ID = @BID"
        Else
            query = "SELECT COUNT(*) FROM FULL_BOOKING_UNITS_NEW WHERE C_OUT = 1 AND B_TYPE = 'OUT' AND B_ID = @BID"
        End If

        Dim countObj = openConnection.GetValueFromQueryWithParams(query, New List(Of SqlParameter) From {
    New SqlParameter("@BID", Convert.ToInt32(txtB_ID.Text))
})

        Return If(IsDBNull(countObj), 0S, Convert.ToInt16(countObj))
    End Function
    Function getContainersList(Optional bNumber As String = "") As String
        Dim result As New StringBuilder()
        Dim query As String
        Dim containerType As String = If(radioIN.Checked, "IN", "OUT")

        query = $"
        SELECT FU.CNTNO, 
               {(If(containerType = "IN", "B_Indate", "B_outDATE"))} AS Date_, 
               {(If(containerType = "IN", "Intime", "Outtime"))} AS Time_, 
               {(If(containerType = "IN", "IN_A_ID", "OUT_A_ID"))} AS A_ID_
        FROM Full_BOOKING_UNITS_NEW FU
        LEFT JOIN FULL_DAILY FD ON FU.{(If(containerType = "IN", "IN_A_ID", "OUT_A_ID"))} = FD.A_ID
        WHERE C_{containerType} = 1 AND B_Type = '{containerType}' AND B_ID IN 
            (SELECT B_ID FROM FULL_BOOKING_NEW WHERE B_TYPE = '{containerType}' AND B_NUMBER = @BNumber)
    "

        Dim dt = openConnection.GetDataTable(query, New List(Of SqlParameter) From {
        New SqlParameter("@BNumber", If(String.IsNullOrWhiteSpace(bNumber), txtB_Number.Text.Trim(), bNumber))
    })

        Dim SL As Integer = 1
        For Each row As DataRow In dt.Rows
            Dim cnt As String = row("CNTNO").ToString().Trim()
            cnt = If(cnt.Length > 11, cnt.Substring(cnt.Length - 11), cnt)

            result.AppendFormat("{0}. {1}   Date: {2}   Time: {3}<br>", SL, cnt, row("Date_"), row("Time_"))

            If Not IsDBNull(row("A_ID_")) AndAlso Not String.IsNullOrWhiteSpace(row("A_ID_").ToString()) Then
                result.AppendLine(getServicesUsed(Convert.ToInt32(row("A_ID_"))) & "<br><br>")
            Else
                result.AppendLine("No services data.<br><br>")
            End If

            SL += 1
        Next

        Return result.ToString()
    End Function

    Function getServicesUsed(ByVal A_ID As Integer) As String
        If A_ID = 0 Then Return ""

        Dim query As String = "
        SELECT cs.A_ID, Srvc_Job_Order, Outposted, Halaname, Srvc_ID,
               d.Cust_ID, cust_Name, SrvcName, Srvc_Unit, Srvc_Rate,
               Srvc_UnitRequested, srvc_Cost, Srvc_Added_Date, Srvc_Completed,
               Srvc_Completed_Date, cs.Goods, DaysRequested, cntno,
               srvceng, srvcarb, Indate, Outdate
        FROM Customer_Services cs
        LEFT JOIN ServicesNew s ON cs.Srvc_ID = s.SrvcCode
        LEFT JOIN full_Daily d ON cs.A_ID = d.A_ID
        WHERE s.deleted = 0 AND srvc_deleted = 0 AND Srvc_Job_Order <> 0 AND cs.A_ID = @AID"

        Dim dt = openConnection.GetDataTable(query, New List(Of SqlParameter) From {
        New SqlParameter("@AID", A_ID)
    })

        If dt.Rows.Count = 0 Then Return ""

        Dim sb As New StringBuilder()
        Dim counter As Integer = 1

        For Each row As DataRow In dt.Rows
            sb.AppendLine($"<br>{counter}) Service Name: {row("srvceng")}<br>")
            sb.AppendLine($"Service Added Date: {If(IsDBNull(row("Srvc_Added_Date")), "", row("Srvc_Added_Date").ToString())}<br>")
            sb.AppendLine($"Service Rate: {row("Srvc_Rate")}<br>")
            sb.AppendLine($"Service Unit: {row("Srvc_Unit")}<br>")
            sb.AppendLine($"Unit Requested: {row("Srvc_UnitRequested")}<br>")
            sb.AppendLine($"Service Cost: {row("Srvc_Cost")}<br>")
            sb.AppendLine($"Service Completed: {If(Convert.ToBoolean(row("Srvc_Completed")), "Yes", "No")}<br>")
            sb.AppendLine($"Service Completed Date: {If(Convert.ToBoolean(row("Srvc_Completed")) AndAlso Not IsDBNull(row("Srvc_Completed_Date")), row("Srvc_Completed_Date").ToString(), "")}<br>")
            counter += 1
        Next

        Return sb.ToString()
    End Function

    Private Sub btnUploadUnits_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUploadUnits.Click
        If flagEdit = False Then Exit Sub

        Dim checkUnits As Short = getContainersCount()

        If String.IsNullOrWhiteSpace(TxtEditCntno.Text) Then
            MsgBox("Please Add the Container Numbers For this Booking. Not Saved")
            Exit Sub
        End If

        Dim arr() As String = TxtEditCntno.Text.Split({vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
        Dim countItem As Integer = 0

        For Each Containerz In arr
            Dim trimmedContainer = Containerz.Trim()
            If trimmedContainer <> "" Then
                countItem += 1

                If Not checkContainer(trimmedContainer) Then
                    MsgBox(trimmedContainer & " container number you entered is not correct. Not Saved")
                    Exit Sub
                End If

                If radioIN.Checked Then
                    If checkInYardAndLine(trimmedContainer, Convert.ToInt16(ComboCustomer.Text)) Then
                        MsgBox(trimmedContainer & " container is already inside the Yard. You cannot Add this Container")
                        Exit Sub
                    End If
                End If
            End If
        Next

        ' Perform update and insert
        For Each Containerz In arr
            Dim trimmedContainer = Containerz.Trim()
            If trimmedContainer <> "" Then
                Dim success As Boolean = openConnection.ExecuteNonQueryWithStatus(
                "UPDATE Full_BOOKING_NEW SET B_Qty = @Qty WHERE B_ID = @BID",
                New List(Of SqlParameter) From {
                    New SqlParameter("@Qty", Convert.ToInt32(txtQty.Text)),
                    New SqlParameter("@BID", Convert.ToInt32(txtB_ID.Text))
                }
            )

                If success Then
                    insertSingleContainer(trimmedContainer)
                End If
            End If
        Next

        MsgBox("Container Updated Successfully")
        refreshData()
        Frame3.Visible = False

        openConnection.ExecuteSQLWithParameters(
        "UPDATE Full_BOOKING_NEW SET ToCloud = 0 WHERE B_ID = @BID",
        New List(Of SqlParameter) From {
            New SqlParameter("@BID", Convert.ToInt32(txtB_ID.Text))
        }
    )

        flagEdit = False
        TxtEditCntno.Text = ""
    End Sub
    Private Sub btnCancelUpload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelUpload.Click
        Frame3.Visible = False
        flagEdit = False
        TxtEditCntno.Text = ""
        clearAll()
    End Sub
    Private Sub dgBooking_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgBooking.CellClick
        If flagNew OrElse e.RowIndex < 0 Then Exit Sub

        Dim selectedRow As DataGridViewRow = dgBooking.Rows(e.RowIndex)
        Dim bookingIdText As String = Convert.ToString(selectedRow.Cells("B_ID").Value)?.Trim()

        If String.IsNullOrEmpty(bookingIdText) OrElse Not Integer.TryParse(bookingIdText, Nothing) Then Exit Sub

        Dim bookingId As Integer = Convert.ToInt32(bookingIdText)
        Dim query As String = "SELECT * FROM Full_BOOKING_NEW WHERE B_ID = @BID AND deleted = 0"
        Dim dt As DataTable = openConnection.GetDataTable(query, New List(Of SqlParameter) From {
        New SqlParameter("@BID", bookingId)
    })

        If dt.Rows.Count = 0 Then Exit Sub

        Dim row = dt.Rows(0)
        Dim bType As String = row("B_Type").ToString().ToUpper()

        If bType = "IN" Then
            radioIN.Checked = True
            Label2_11.Visible = True
            Combo1.Visible = True
        Else
            radioOut.Checked = True
            Label2_11.Visible = False
            Combo1.Visible = False
        End If

        Label2_12.Visible = True
        picETA.Visible = True

        ' Populate fields
        ComboCustomer.SelectedValue = row("cust_id").ToString()
        txtB_ID.Text = row("B_ID").ToString()
        radioManual.Checked = True
        txtB_Number.Text = row("B_Number").ToString()
        comboVessel.Text = NullOrNot(row("VesselName"))
        txtB_Email.Text = NullOrNot(row("B_Sender"))
        ComboFromCity.Text = NullOrNot(row("fromCity"))
        ComboFromLoc.Text = NullOrNot(row("fromLoc"))
        ComboToCity.Text = NullOrNot(row("ToCity"))
        ComboToLoc.Text = NullOrNot(row("ToLoc"))
        txtRecitNo.Text = NullOrNot(row("RecitNo"))

        If row("B_DTtm") IsNot DBNull.Value Then
            dtEmail.Value = Convert.ToDateTime(row("B_DTtm"))
        End If

        txtCntNo.Text = getContainers(row("B_ID").ToString())
        txtQty.Text = row("B_Qty").ToString()
        Combo1.Text = NullOrNot(row("SlineName"))

        ' Parse ETA
        Dim eta As String = NullOrNot(row("txtETA"))
        If Not String.IsNullOrEmpty(eta) AndAlso eta.Length >= 10 Then
            txtEtaDay.Text = eta.Substring(8, 2)
            txtEtaMonth.Text = eta.Substring(5, 2)
            txtETAYear.Text = eta.Substring(0, 4)
        End If

        ' Lock fields
        txtB_ID.Enabled = False
        radioManual.Enabled = False
        radioAuto.Enabled = False
        txtB_Number.Enabled = False
        txtB_Email.Enabled = False
        Frame4.Enabled = False
        txtRecitNo.Enabled = False
        dtEmail.Enabled = False
        txtCntNo.Enabled = False
        txtQty.Enabled = False

        ' Button visibility
        cmdEdit.Enabled = True
        cmdNew.Enabled = True
        cmdSave.Enabled = False
        Label1.Visible = False
        cmdAdd.Visible = False
        cmdAddMore.Visible = False
        cmdChange.Visible = False
        cmdDelete.Visible = False
        cmdCEdit.Visible = False
        Frame1.Enabled = Not flagEdit

        ' Vessel access
        Dim canShowVessel = checkReadOutVessel()
        comboVessel.Visible = canShowVessel
        cmdAddVessel.Visible = canShowVessel
    End Sub

    Function getContainers(ByVal B_ID As Integer) As String
        Dim result As New StringBuilder()
        Dim query As String = "SELECT Cntno FROM Full_BOOKING_UNITS_NEW WHERE B_ID = @BID"

        Dim dt As DataTable = openConnection.GetDataTable(query, New List(Of SqlParameter) From {
        New SqlParameter("@BID", B_ID)
    })

        For Each row As DataRow In dt.Rows
            Dim cntNo As String = row("Cntno").ToString().Trim()
            If cntNo.Length > 11 Then
                cntNo = cntNo.Substring(cntNo.Length - 11)
            End If
            result.AppendLine(cntNo)
        Next

        Return result.ToString()
    End Function

    Function getContainersCount() As Short
        Dim count As Object = openConnection.GetSingleValueWithParams(
        "SELECT COUNT(Cntno) FROM Full_BOOKING_UNITS_NEW WHERE B_ID = @BID",
        New List(Of SqlParameter) From {
            New SqlParameter("@BID", Convert.ToInt32(txtB_ID.Text))
        }
    )

        Return If(IsDBNull(count), 0S, Convert.ToInt16(count))
    End Function

    Private Sub frmBooking_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub fillCombo()
        Dim emptyFullValue As Integer = If(optEmpty.Checked, 1, 2)

        ' ✅ Load FromCity
        Dim dtFromCity = openConnection.GetDataTable("SELECT LocName FROM msklocations WHERE City = 1 AND showinFromCity = 1 AND EMPTYFULL = @ef AND LocName LIKE '%[a-zA-Z]%' ORDER BY LocName",
        New List(Of SqlParameter) From {New SqlParameter("@ef", emptyFullValue)})
        With ComboFromCity
            .DataSource = dtFromCity
            .DisplayMember = "LocName"
            .ValueMember = "LocName"
            .SelectedIndex = -1
        End With

        ' ✅ Load ToCity
        Dim dtToCity = openConnection.GetDataTable("SELECT LocName FROM msklocations WHERE City = 1 AND showinToCity = 1 AND EMPTYFULL = @ef AND LocName LIKE '%[a-zA-Z]%' ORDER BY LocName",
        New List(Of SqlParameter) From {New SqlParameter("@ef", emptyFullValue)})
        With ComboToCity
            .DataSource = dtToCity
            .DisplayMember = "LocName"
            .ValueMember = "LocName"
            .SelectedIndex = -1
        End With

        ' ✅ Load FromLoc
        Dim dtFromLoc = openConnection.GetDataTable("SELECT LocName FROM msklocations WHERE City = 0 AND showinFromLoc = 1 AND EMPTYFULL = @ef AND LocName LIKE '%[a-zA-Z]%' ORDER BY LocName",
        New List(Of SqlParameter) From {New SqlParameter("@ef", emptyFullValue)})
        With ComboFromLoc
            .DataSource = dtFromLoc
            .DisplayMember = "LocName"
            .ValueMember = "LocName"
            .SelectedIndex = -1
        End With

        ' ✅ Load ToLoc
        Dim dtToLoc = openConnection.GetDataTable("SELECT LocName FROM msklocations WHERE City = 0 AND showinToLoc = 1 AND EMPTYFULL = @ef AND LocName LIKE '%[a-zA-Z]%' ORDER BY LocName",
        New List(Of SqlParameter) From {New SqlParameter("@ef", emptyFullValue)})
        With ComboToLoc
            .DataSource = dtToLoc
            .DisplayMember = "LocName"
            .ValueMember = "LocName"
            .SelectedIndex = -1
        End With
    End Sub
    Private Sub refreshVesselName()
        ' ✅ Load Vessel Names
        Dim dtVessels = openConnection.GetDataTable("SELECT ID, VesselName FROM Full_Vessel_List ORDER BY VesselName")
        With comboVessel
            .DataSource = dtVessels
            .DisplayMember = "VesselName"
            .ValueMember = "ID"
            .SelectedIndex = -1
        End With

        ' ✅ Load SLine List into Combo1 (Items.Add style)
        Combo1.Items.Clear()
        Dim dtSLine = openConnection.GetDataTable("SELECT FieldName FROM tblPalletsAllMaster WHERE fieldtype = 'SLINE' AND deleted = 0")
        For Each row As DataRow In dtSLine.Rows
            Combo1.Items.Add(row("FieldName").ToString())
        Next
    End Sub
    Private Sub checkNumber(txt As TextBox)
        If String.IsNullOrWhiteSpace(txt.Text) Then Exit Sub

        If Not Decimal.TryParse(txt.Text, Nothing) Then
            MessageBox.Show("Invalid Value", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt.Focus()
            txt.SelectAll()
        End If
    End Sub
    Private Function checkInYardAndLine(cntno As String, cust_id As Integer) As Boolean
        Dim dt = openConnection.GetDataTable("
        SELECT TOP 1 A_Case 
        FROM Full_Daily 
        WHERE deleted <> 'Y' AND cntno = @cntno 
        ORDER BY A_ID DESC",
        New List(Of SqlParameter) From {
            New SqlParameter("@cntno", cntno)
        })

        If dt.Rows.Count = 0 Then Return False

        Return Convert.ToInt32(dt.Rows(0)("A_Case")) = 1
    End Function
    Private Sub clearAll()
        Combo1.Enabled = False
        Frame4.Enabled = False
        Combo1.Text = ""
        lblLabel.Visible = False
        Label1.Visible = False

        cmdAdd.Visible = False
        cmdAddMore.Visible = False
        cmdDelete.Visible = False
        cmdCEdit.Visible = False
        cmdChange.Visible = False
        ComboCustomer.Enabled = False

        txtB_ID.Enabled = False
        txtB_Number.Enabled = False
        radioAuto.Enabled = False
        txtB_Email.Enabled = False
        txtRecitNo.Enabled = False
        dtEmail.Enabled = False
        txtQty.Enabled = False
        txtCntNo.Enabled = False

        flagNew = False
        flagEdit = False

        btnDeleteBooking.Enabled = True
        radioIN.Checked = False
        radioOut.Checked = False

        ComboCustomer.Text = ""
        txtB_ID.Text = ""
        txtB_Number.Text = ""
        radioAuto.Checked = True
        txtB_Email.Text = ""
        ComboFromCity.Text = ""
        ComboFromLoc.Text = ""
        ComboToCity.Text = ""
        ComboToLoc.Text = ""
        txtRecitNo.Text = ""
        dtEmail.Value = Now
        txtQty.Text = ""
        comboVessel.Text = ""
        txtCntNo.Text = ""
        txtSearch.Text = ""

        cmdNew.Enabled = True
        cmdEdit.Enabled = True
        cmdSave.Enabled = False
        cmdCancel.Enabled = True
        cmdExit.Enabled = True
    End Sub

    Private Sub rdoShowAll_CheckedChanged(sender As Object, e As EventArgs) Handles rdoShowAll.CheckedChanged
        If isFormLoading OrElse Not rdoShowAll.Checked Then Return
        updateFGBooking()
    End Sub

    Private Sub rdoShowCompleted_CheckedChanged(sender As Object, e As EventArgs) Handles rdoShowCompleted.CheckedChanged
        If isFormLoading OrElse Not rdoShowCompleted.Checked Then Return
        updateFGBooking()
    End Sub

    Private Sub rdoRunning_CheckedChanged(sender As Object, e As EventArgs) Handles rdoRunning.CheckedChanged
        If isFormLoading OrElse Not rdoRunning.Checked Then Return
        updateFGBooking()
    End Sub

    Private Sub radioAuto_CheckedChanged(sender As Object, e As EventArgs) Handles radioAuto.CheckedChanged
        If isFormLoading OrElse Not radioAuto.Checked Then Return
        txtB_Number.Text = ""
        txtB_Number.Enabled = False
    End Sub
    Private Sub LoadCustomersForBooking(isInbound As Boolean)
        Dim sql As String = "
        SELECT Cust_ID, Cust_Name 
        FROM Full_Customers 
        WHERE (deleted = 0 OR deleted IS NULL) AND " & If(isInbound, "B_IN = 1", "B_OUT = 1") & " 
        ORDER BY Cust_Name"

        dtCustomers = openConnection.GetDataTable(sql)
        dtSearchCustomers = dtCustomers.Copy()

        With ComboCustomer
            .DataSource = dtCustomers
            .DisplayMember = "Cust_Name"
            .ValueMember = "Cust_ID"
            .SelectedIndex = -1
        End With

        With ComboSearch
            .DataSource = dtSearchCustomers
            .DisplayMember = "Cust_Name"
            .ValueMember = "Cust_ID"
            .SelectedIndex = -1
        End With
    End Sub
    Private Sub radioIN_CheckedChanged(sender As Object, e As EventArgs) Handles radioIN.CheckedChanged
        If isFormLoading OrElse Not radioIN.Checked Then Return

        LoadCustomersForBooking(isInbound:=True)
        updateFGBooking()

        Label2_11.Visible = True
        Combo1.Visible = True
        Label2_12.Visible = True
        picETA.Visible = True
    End Sub
    Private Sub radioOut_CheckedChanged(sender As Object, e As EventArgs) Handles radioOut.CheckedChanged
        If isFormLoading OrElse Not radioOut.Checked Then Return

        LoadCustomersForBooking(isInbound:=False)
        updateFGBooking()

        Label2_11.Visible = False
        Combo1.Visible = False
        Label2_12.Visible = True
        picETA.Visible = True
    End Sub
    Private Sub radioManual_CheckedChanged(sender As Object, e As EventArgs) Handles radioManual.CheckedChanged
        If isFormLoading OrElse Not radioManual.Checked Then Return

        txtB_Number.Text = ""
        If flagNew Then txtB_Number.Enabled = True
    End Sub
    Private Sub txtQty_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtQty.Validating
        Dim input = txtQty.Text.Trim()

        If String.IsNullOrWhiteSpace(input) Then
            MessageBox.Show("Quantity cannot be blank.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQty.Select()
            e.Cancel = True
            Return
        End If

        If Not IsNumeric(input) OrElse Convert.ToInt32(input) <= 0 Then
            MessageBox.Show("Invalid Quantity. Enter a valid number greater than 0.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQty.Select()
            e.Cancel = True
        End If
    End Sub

    Private Sub updateFGBooking()

        Try
            ' Clear DataGridView setup
            dgBooking.Columns.Clear()
            dgBooking.Rows.Clear()

            ' Setup columns
            dgBooking.ColumnCount = 9
            dgBooking.Columns(0).Name = "S.No"
            dgBooking.Columns(1).Name = "B_ID"
            dgBooking.Columns(2).Name = "Booking"
            dgBooking.Columns(3).Name = "Customer"
            dgBooking.Columns(4).Name = "Date"
            dgBooking.Columns(5).Name = "Quantity"
            dgBooking.Columns(6).Name = "Completed"
            dgBooking.Columns(7).Name = "Balance"
            dgBooking.Columns(8).Name = "Offloaded"

            ' Align center
            For i As Integer = 0 To dgBooking.Columns.Count - 1
                dgBooking.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            ' Optional widths
            dgBooking.Columns(0).Width = 40
            dgBooking.Columns(1).Width = 50
            dgBooking.Columns(2).Width = 180
            dgBooking.Columns(3).Width = 180
            dgBooking.Columns(4).Width = 100
            dgBooking.Columns(5).Width = 80
            dgBooking.Columns(6).Width = 80
            dgBooking.Columns(7).Width = 80
            dgBooking.Columns(8).Width = 80

            ' Get data using openConnection
            Dim dt As DataTable = openConnection.GetDataTable(getSqlString)

            Dim rowCounter As Integer = 1
            For Each row As DataRow In dt.Rows
                dgBooking.Rows.Add(New Object() {
                rowCounter,
                row("B_ID"),
                row("B_Number"),
                NullOrNot(row("Cust_Name")),
                Format(row("CreatedOn"), "dd-MM-yyyy"),
                row("B_Qty"),
                row("completed"),
                row("balance"),
                NullOrNot(row("rcvd"))
            })
                rowCounter += 1
            Next

        Catch ex As Exception
            ErrMsg()
        End Try
    End Sub
    Private Function getSqlString() As String
        Dim baseQuery As String = "
SELECT * FROM (
    SELECT 
        B.B_ID AS B_ID,
        B.RecitNo,
        C.Cust_Name,
        B.B_Type,
        B.B_Number,
        B.B_Qty,
        Completed = B.B_Qty - ISNULL(IN_PENDING.IN_C, 0),
        Balance = ISNULL(IN_PENDING.IN_C, 0) + ISNULL(OUT_PENDING.OUT_C, 0),
        B.CreatedOn,
        B.Cust_ID,
        Rcvd = ISNULL(B.Rcvd, 0)
    FROM Full_BOOKING_NEW B
    LEFT JOIN (
        SELECT COUNT(*) AS IN_C, B_ID
        FROM Full_BOOKING_UNITS_NEW
        WHERE C_IN = 0 AND B_Type = 'IN'
        GROUP BY B_ID
    ) IN_PENDING ON B.B_ID = IN_PENDING.B_ID
    LEFT JOIN (
        SELECT COUNT(*) AS OUT_C, B_ID
        FROM Full_BOOKING_UNITS_NEW
        WHERE C_OUT = 0 AND B_Type = 'OUT'
        GROUP BY B_ID
    ) OUT_PENDING ON B.B_ID = OUT_PENDING.B_ID
    LEFT JOIN Full_Customers C ON B.Cust_ID = C.Cust_ID
    WHERE B.Deleted <> 1
) AS closedAll
WHERE B_ID <> 0
"

        Dim whereClause As New List(Of String)

        ' Filters
        If rdoShowCompleted.Checked Then
            whereClause.Add("Balance = 0")
        ElseIf rdoRunning.Checked Then
            whereClause.Add("Balance <> 0")
        End If

        If Not String.IsNullOrWhiteSpace(ComboSearch.Text) AndAlso ComboSearch.SelectedValue IsNot Nothing Then
            Dim selectedVal As Object = ComboSearch.SelectedValue
            If Not TypeOf selectedVal Is DataRowView Then
                whereClause.Add("Cust_ID = " & Convert.ToInt32(selectedVal))
            End If
        End If

        If radioIN.Checked Then
            whereClause.Add("B_Type = 'IN'")
        ElseIf radioOut.Checked Then
            whereClause.Add("B_Type = 'OUT'")
        End If

        If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
            whereClause.Add("CHARINDEX('" & txtSearch.Text.Trim().Replace("'", "''") & "', B_Number) <> 0")
        End If

        ' Combine filters
        If whereClause.Count > 0 Then
            baseQuery &= " AND " & String.Join(" AND ", whereClause)
        End If

        txtQueryPreview.Text = baseQuery
        Return baseQuery
    End Function


    Private Sub ComboSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboSearch.SelectedIndexChanged
        updateFGBooking()
    End Sub
End Class