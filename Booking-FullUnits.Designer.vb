<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Booking_FullUnits
    Inherits BaseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Booking_FullUnits))
        Me.Command3 = New System.Windows.Forms.Button()
        Me.Option1 = New System.Windows.Forms.RadioButton()
        Me.Option2 = New System.Windows.Forms.RadioButton()
        Me.Option3 = New System.Windows.Forms.RadioButton()
        Me.radioAuto = New System.Windows.Forms.RadioButton()
        Me.radioManual = New System.Windows.Forms.RadioButton()
        Me.ComboSearch = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtB_Email = New System.Windows.Forms.TextBox()
        Me.radioIN = New System.Windows.Forms.RadioButton()
        Me.Command2 = New System.Windows.Forms.Button()
        Me.Frame2 = New System.Windows.Forms.Panel()
        Me._Label2_8 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.txtB_ID = New System.Windows.Forms.TextBox()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.txtCntNo = New System.Windows.Forms.TextBox()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me._Label2_9 = New System.Windows.Forms.Label()
        Me._Label2_2 = New System.Windows.Forms.Label()
        Me._Label2_0 = New System.Windows.Forms.Label()
        Me._Label2_7 = New System.Windows.Forms.Label()
        Me._Label2_1 = New System.Windows.Forms.Label()
        Me._Label2_3 = New System.Windows.Forms.Label()
        Me._Label2_4 = New System.Windows.Forms.Label()
        Me._Label2_5 = New System.Windows.Forms.Label()
        Me._Label2_6 = New System.Windows.Forms.Label()
        Me.cmdCEdit = New System.Windows.Forms.Button()
        Me.ComboCustomer = New System.Windows.Forms.ComboBox()
        Me.txtCntnoRT = New System.Windows.Forms.PictureBox()
        Me.comboVessel = New System.Windows.Forms.ComboBox()
        Me.radioOut = New System.Windows.Forms.RadioButton()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me._Label2_18 = New System.Windows.Forms.Label()
        Me.Label2_12 = New System.Windows.Forms.Label()
        Me.Label2_11 = New System.Windows.Forms.Label()
        Me._Label2_10 = New System.Windows.Forms.Label()
        Me.ComboFromCity = New System.Windows.Forms.ComboBox()
        Me.ComboFromLoc = New System.Windows.Forms.ComboBox()
        Me.Text1 = New System.Windows.Forms.TextBox()
        Me.Check1 = New System.Windows.Forms.CheckBox()
        Me.ComboToCity = New System.Windows.Forms.ComboBox()
        Me.picETA = New System.Windows.Forms.Panel()
        Me.txtEtaDay = New System.Windows.Forms.TextBox()
        Me.txtEtaMonth = New System.Windows.Forms.TextBox()
        Me.txtETAYear = New System.Windows.Forms.TextBox()
        Me._Label2_13 = New System.Windows.Forms.Label()
        Me.Labelbar = New System.Windows.Forms.Label()
        Me.Frame1 = New System.Windows.Forms.Panel()
        Me.ComboToLoc = New System.Windows.Forms.ComboBox()
        Me.optEmpty = New System.Windows.Forms.RadioButton()
        Me._Label2_14 = New System.Windows.Forms.Label()
        Me.optFull = New System.Windows.Forms.RadioButton()
        Me.Frame5 = New System.Windows.Forms.Panel()
        Me.Frame4 = New System.Windows.Forms.Panel()
        Me._Label2_15 = New System.Windows.Forms.Label()
        Me._Label2_16 = New System.Windows.Forms.Label()
        Me._Label2_17 = New System.Windows.Forms.Label()
        Me.cmdChange = New System.Windows.Forms.Button()
        Me.txtRecitNo = New System.Windows.Forms.TextBox()
        Me.Picture1 = New System.Windows.Forms.Panel()
        Me.cmdNew = New System.Windows.Forms.Button()
        Me.lblLabel = New System.Windows.Forms.Label()
        Me.txtB_Number = New System.Windows.Forms.TextBox()
        Me.Command5 = New System.Windows.Forms.Button()
        Me.Combo1 = New System.Windows.Forms.ComboBox()
        Me.cmdAddMore = New System.Windows.Forms.Button()
        Me.cmdAddVessel = New System.Windows.Forms.Button()
        Me.Command4 = New System.Windows.Forms.Button()
        Me.Frame3 = New System.Windows.Forms.GroupBox()
        Me.TxtEditCntno = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgBooking = New System.Windows.Forms.DataGridView()
        Me.dtEmail = New System.Windows.Forms.DateTimePicker()
        Me.Frame2.SuspendLayout()
        CType(Me.txtCntnoRT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.picETA.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.Frame5.SuspendLayout()
        Me.Frame4.SuspendLayout()
        Me.Picture1.SuspendLayout()
        Me.Frame3.SuspendLayout()
        CType(Me.dgBooking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.SystemColors.Control
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New System.Drawing.Point(796, 5)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(75, 42)
        Me.Command3.TabIndex = 63
        Me.Command3.Text = "Search"
        Me.Command3.UseVisualStyleBackColor = False
        '
        'Option1
        '
        Me.Option1.AutoSize = True
        Me.Option1.BackColor = System.Drawing.SystemColors.Control
        Me.Option1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option1.ForeColor = System.Drawing.Color.Blue
        Me.Option1.Location = New System.Drawing.Point(336, 23)
        Me.Option1.Name = "Option1"
        Me.Option1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option1.Size = New System.Drawing.Size(79, 21)
        Me.Option1.TabIndex = 23
        Me.Option1.TabStop = True
        Me.Option1.Text = "Show All"
        Me.Option1.UseVisualStyleBackColor = False
        '
        'Option2
        '
        Me.Option2.AutoSize = True
        Me.Option2.BackColor = System.Drawing.SystemColors.Control
        Me.Option2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option2.ForeColor = System.Drawing.Color.Blue
        Me.Option2.Location = New System.Drawing.Point(421, 23)
        Me.Option2.Name = "Option2"
        Me.Option2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option2.Size = New System.Drawing.Size(133, 21)
        Me.Option2.TabIndex = 22
        Me.Option2.TabStop = True
        Me.Option2.Text = "Show Completed"
        Me.Option2.UseVisualStyleBackColor = False
        '
        'Option3
        '
        Me.Option3.AutoSize = True
        Me.Option3.BackColor = System.Drawing.SystemColors.Control
        Me.Option3.Checked = True
        Me.Option3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option3.ForeColor = System.Drawing.Color.Blue
        Me.Option3.Location = New System.Drawing.Point(560, 23)
        Me.Option3.Name = "Option3"
        Me.Option3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option3.Size = New System.Drawing.Size(80, 21)
        Me.Option3.TabIndex = 21
        Me.Option3.TabStop = True
        Me.Option3.Text = "Running"
        Me.Option3.UseVisualStyleBackColor = False
        '
        'radioAuto
        '
        Me.radioAuto.AutoSize = True
        Me.radioAuto.BackColor = System.Drawing.SystemColors.Control
        Me.radioAuto.Cursor = System.Windows.Forms.Cursors.Default
        Me.radioAuto.ForeColor = System.Drawing.Color.Blue
        Me.radioAuto.Location = New System.Drawing.Point(140, 172)
        Me.radioAuto.Name = "radioAuto"
        Me.radioAuto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.radioAuto.Size = New System.Drawing.Size(63, 21)
        Me.radioAuto.TabIndex = 91
        Me.radioAuto.TabStop = True
        Me.radioAuto.Text = "Auto:"
        Me.radioAuto.UseVisualStyleBackColor = False
        '
        'radioManual
        '
        Me.radioManual.AutoSize = True
        Me.radioManual.BackColor = System.Drawing.SystemColors.Control
        Me.radioManual.Cursor = System.Windows.Forms.Cursors.Default
        Me.radioManual.ForeColor = System.Drawing.Color.Blue
        Me.radioManual.Location = New System.Drawing.Point(209, 172)
        Me.radioManual.Name = "radioManual"
        Me.radioManual.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.radioManual.Size = New System.Drawing.Size(71, 21)
        Me.radioManual.TabIndex = 90
        Me.radioManual.TabStop = True
        Me.radioManual.Text = "Manual"
        Me.radioManual.UseVisualStyleBackColor = False
        '
        'ComboSearch
        '
        Me.ComboSearch.Location = New System.Drawing.Point(73, 4)
        Me.ComboSearch.Name = "ComboSearch"
        Me.ComboSearch.Size = New System.Drawing.Size(257, 24)
        Me.ComboSearch.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(650, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(58, 17)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "Order#:"
        '
        'txtB_Email
        '
        Me.txtB_Email.AcceptsReturn = True
        Me.txtB_Email.BackColor = System.Drawing.SystemColors.Window
        Me.txtB_Email.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtB_Email.ForeColor = System.Drawing.Color.Blue
        Me.txtB_Email.Location = New System.Drawing.Point(212, 324)
        Me.txtB_Email.MaxLength = 0
        Me.txtB_Email.Name = "txtB_Email"
        Me.txtB_Email.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtB_Email.Size = New System.Drawing.Size(257, 24)
        Me.txtB_Email.TabIndex = 83
        Me.txtB_Email.Text = "Text1"
        Me.txtB_Email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'radioIN
        '
        Me.radioIN.AutoSize = True
        Me.radioIN.BackColor = System.Drawing.SystemColors.Control
        Me.radioIN.Cursor = System.Windows.Forms.Cursors.Default
        Me.radioIN.ForeColor = System.Drawing.Color.Blue
        Me.radioIN.Location = New System.Drawing.Point(4, 8)
        Me.radioIN.Name = "radioIN"
        Me.radioIN.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.radioIN.Size = New System.Drawing.Size(67, 21)
        Me.radioIN.TabIndex = 1
        Me.radioIN.TabStop = True
        Me.radioIN.Text = "Gatein"
        Me.radioIN.UseVisualStyleBackColor = False
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(608, 8)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(89, 33)
        Me.Command2.TabIndex = 48
        Me.Command2.Text = "Email Status"
        Me.Command2.UseVisualStyleBackColor = False
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.Command3)
        Me.Frame2.Controls.Add(Me.Option1)
        Me.Frame2.Controls.Add(Me.Option2)
        Me.Frame2.Controls.Add(Me.Option3)
        Me.Frame2.Controls.Add(Me.ComboSearch)
        Me.Frame2.Controls.Add(Me.Label3)
        Me.Frame2.Controls.Add(Me._Label2_8)
        Me.Frame2.Controls.Add(Me.txtSearch)
        Me.Frame2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(523, 55)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(874, 58)
        Me.Frame2.TabIndex = 89
        Me.Frame2.Text = "Frame2"
        '
        '_Label2_8
        '
        Me._Label2_8.AutoSize = True
        Me._Label2_8.BackColor = System.Drawing.Color.Transparent
        Me._Label2_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_8.ForeColor = System.Drawing.Color.Black
        Me._Label2_8.Location = New System.Drawing.Point(3, 4)
        Me._Label2_8.Name = "_Label2_8"
        Me._Label2_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_8.Size = New System.Drawing.Size(73, 17)
        Me._Label2_8.TabIndex = 25
        Me._Label2_8.Text = "Customer:"
        '
        'txtSearch
        '
        Me.txtSearch.AcceptsReturn = True
        Me.txtSearch.BackColor = System.Drawing.SystemColors.Window
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSearch.Location = New System.Drawing.Point(653, 23)
        Me.txtSearch.MaxLength = 0
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSearch.Size = New System.Drawing.Size(137, 24)
        Me.txtSearch.TabIndex = 108
        '
        'txtB_ID
        '
        Me.txtB_ID.AcceptsReturn = True
        Me.txtB_ID.BackColor = System.Drawing.SystemColors.Window
        Me.txtB_ID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtB_ID.Enabled = False
        Me.txtB_ID.ForeColor = System.Drawing.Color.Blue
        Me.txtB_ID.Location = New System.Drawing.Point(500, 204)
        Me.txtB_ID.MaxLength = 0
        Me.txtB_ID.Name = "txtB_ID"
        Me.txtB_ID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtB_ID.Size = New System.Drawing.Size(257, 24)
        Me.txtB_ID.TabIndex = 78
        Me.txtB_ID.Text = "Text1"
        Me.txtB_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtB_ID.Visible = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(296, 8)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(89, 33)
        Me.Command1.TabIndex = 45
        Me.Command1.Text = "Delete Booking"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(504, 8)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(89, 33)
        Me.cmdExit.TabIndex = 32
        Me.cmdExit.Text = "Exit Form"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSave.Enabled = False
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSave.Location = New System.Drawing.Point(400, 8)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSave.Size = New System.Drawing.Size(89, 33)
        Me.cmdSave.TabIndex = 16
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(192, 8)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(89, 33)
        Me.cmdCancel.TabIndex = 31
        Me.cmdCancel.Text = "Cancel/Clear"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdEdit
        '
        Me.cmdEdit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdEdit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdEdit.Location = New System.Drawing.Point(96, 8)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdEdit.Size = New System.Drawing.Size(89, 33)
        Me.cmdEdit.TabIndex = 30
        Me.cmdEdit.Text = "Edit"
        Me.cmdEdit.UseVisualStyleBackColor = False
        '
        'txtQty
        '
        Me.txtQty.AcceptsReturn = True
        Me.txtQty.BackColor = System.Drawing.SystemColors.Window
        Me.txtQty.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQty.ForeColor = System.Drawing.Color.Blue
        Me.txtQty.Location = New System.Drawing.Point(404, 356)
        Me.txtQty.MaxLength = 0
        Me.txtQty.Name = "txtQty"
        Me.txtQty.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtQty.Size = New System.Drawing.Size(65, 24)
        Me.txtQty.TabIndex = 84
        Me.txtQty.Text = "Text1"
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCntNo
        '
        Me.txtCntNo.AcceptsReturn = True
        Me.txtCntNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtCntNo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCntNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCntNo.Location = New System.Drawing.Point(212, 402)
        Me.txtCntNo.MaxLength = 0
        Me.txtCntNo.Multiline = True
        Me.txtCntNo.Name = "txtCntNo"
        Me.txtCntNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCntNo.Size = New System.Drawing.Size(281, 263)
        Me.txtCntNo.TabIndex = 85
        Me.txtCntNo.Text = "Text1"
        '
        'cmdDelete
        '
        Me.cmdDelete.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDelete.Location = New System.Drawing.Point(4, 618)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDelete.Size = New System.Drawing.Size(193, 33)
        Me.cmdDelete.TabIndex = 88
        Me.cmdDelete.Text = "Delete Container"
        Me.cmdDelete.UseVisualStyleBackColor = False
        Me.cmdDelete.Visible = False
        '
        '_Label2_9
        '
        Me._Label2_9.AutoSize = True
        Me._Label2_9.BackColor = System.Drawing.Color.Transparent
        Me._Label2_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_9.ForeColor = System.Drawing.Color.Black
        Me._Label2_9.Location = New System.Drawing.Point(292, 156)
        Me._Label2_9.Name = "_Label2_9"
        Me._Label2_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_9.Size = New System.Drawing.Size(98, 17)
        Me._Label2_9.TabIndex = 104
        Me._Label2_9.Text = "Cash Recit No:"
        Me._Label2_9.Visible = False
        '
        '_Label2_2
        '
        Me._Label2_2.AutoSize = True
        Me._Label2_2.BackColor = System.Drawing.Color.Transparent
        Me._Label2_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_2.ForeColor = System.Drawing.Color.Black
        Me._Label2_2.Location = New System.Drawing.Point(12, 172)
        Me._Label2_2.Name = "_Label2_2"
        Me._Label2_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_2.Size = New System.Drawing.Size(115, 17)
        Me._Label2_2.TabIndex = 103
        Me._Label2_2.Text = "Booking Number:"
        '
        '_Label2_0
        '
        Me._Label2_0.AutoSize = True
        Me._Label2_0.BackColor = System.Drawing.Color.Transparent
        Me._Label2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_0.ForeColor = System.Drawing.Color.Black
        Me._Label2_0.Location = New System.Drawing.Point(12, 140)
        Me._Label2_0.Name = "_Label2_0"
        Me._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_0.Size = New System.Drawing.Size(112, 17)
        Me._Label2_0.TabIndex = 102
        Me._Label2_0.Text = "Customer Name:"
        '
        '_Label2_7
        '
        Me._Label2_7.AutoSize = True
        Me._Label2_7.BackColor = System.Drawing.Color.Transparent
        Me._Label2_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_7.ForeColor = System.Drawing.Color.Black
        Me._Label2_7.Location = New System.Drawing.Point(12, 52)
        Me._Label2_7.Name = "_Label2_7"
        Me._Label2_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_7.Size = New System.Drawing.Size(97, 17)
        Me._Label2_7.TabIndex = 101
        Me._Label2_7.Text = "Booking Type:"
        '
        '_Label2_1
        '
        Me._Label2_1.AutoSize = True
        Me._Label2_1.BackColor = System.Drawing.Color.Transparent
        Me._Label2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_1.ForeColor = System.Drawing.Color.Black
        Me._Label2_1.Location = New System.Drawing.Point(372, 356)
        Me._Label2_1.Name = "_Label2_1"
        Me._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_1.Size = New System.Drawing.Size(36, 17)
        Me._Label2_1.TabIndex = 100
        Me._Label2_1.Text = "Qty:"
        '
        '_Label2_3
        '
        Me._Label2_3.AutoSize = True
        Me._Label2_3.BackColor = System.Drawing.Color.Transparent
        Me._Label2_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_3.ForeColor = System.Drawing.Color.Black
        Me._Label2_3.Location = New System.Drawing.Point(12, 356)
        Me._Label2_3.Name = "_Label2_3"
        Me._Label2_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_3.Size = New System.Drawing.Size(156, 17)
        Me._Label2_3.TabIndex = 99
        Me._Label2_3.Text = "Email Received Dt/Time:"
        '
        '_Label2_4
        '
        Me._Label2_4.AutoSize = True
        Me._Label2_4.BackColor = System.Drawing.Color.Transparent
        Me._Label2_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_4.ForeColor = System.Drawing.Color.Black
        Me._Label2_4.Location = New System.Drawing.Point(12, 327)
        Me._Label2_4.Name = "_Label2_4"
        Me._Label2_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_4.Size = New System.Drawing.Size(130, 17)
        Me._Label2_4.TabIndex = 98
        Me._Label2_4.Text = "Email Sender Name:"
        '
        '_Label2_5
        '
        Me._Label2_5.AutoSize = True
        Me._Label2_5.BackColor = System.Drawing.Color.Transparent
        Me._Label2_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_5.ForeColor = System.Drawing.Color.Black
        Me._Label2_5.Location = New System.Drawing.Point(12, 372)
        Me._Label2_5.Name = "_Label2_5"
        Me._Label2_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_5.Size = New System.Drawing.Size(131, 17)
        Me._Label2_5.TabIndex = 97
        Me._Label2_5.Text = "Container Numbers:"
        '
        '_Label2_6
        '
        Me._Label2_6.AutoSize = True
        Me._Label2_6.BackColor = System.Drawing.Color.Transparent
        Me._Label2_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_6.ForeColor = System.Drawing.Color.Black
        Me._Label2_6.Location = New System.Drawing.Point(476, 180)
        Me._Label2_6.Name = "_Label2_6"
        Me._Label2_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_6.Size = New System.Drawing.Size(80, 17)
        Me._Label2_6.TabIndex = 96
        Me._Label2_6.Text = "Booking ID:"
        Me._Label2_6.Visible = False
        '
        'cmdCEdit
        '
        Me.cmdCEdit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCEdit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCEdit.Location = New System.Drawing.Point(4, 578)
        Me.cmdCEdit.Name = "cmdCEdit"
        Me.cmdCEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCEdit.Size = New System.Drawing.Size(193, 33)
        Me.cmdCEdit.TabIndex = 86
        Me.cmdCEdit.Text = "Change Single Container #"
        Me.cmdCEdit.UseVisualStyleBackColor = False
        Me.cmdCEdit.Visible = False
        '
        'ComboCustomer
        '
        Me.ComboCustomer.Location = New System.Drawing.Point(212, 132)
        Me.ComboCustomer.Name = "ComboCustomer"
        Me.ComboCustomer.Size = New System.Drawing.Size(265, 24)
        Me.ComboCustomer.TabIndex = 77
        '
        'txtCntnoRT
        '
        Me.txtCntnoRT.BackColor = System.Drawing.SystemColors.Control
        Me.txtCntnoRT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtCntnoRT.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtCntnoRT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCntnoRT.Location = New System.Drawing.Point(220, 402)
        Me.txtCntnoRT.Name = "txtCntnoRT"
        Me.txtCntnoRT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCntnoRT.Size = New System.Drawing.Size(257, 257)
        Me.txtCntnoRT.TabIndex = 94
        Me.txtCntnoRT.TabStop = False
        '
        'comboVessel
        '
        Me.comboVessel.Location = New System.Drawing.Point(212, 196)
        Me.comboVessel.Name = "comboVessel"
        Me.comboVessel.Size = New System.Drawing.Size(241, 24)
        Me.comboVessel.TabIndex = 80
        Me.comboVessel.Visible = False
        '
        'radioOut
        '
        Me.radioOut.AutoSize = True
        Me.radioOut.BackColor = System.Drawing.SystemColors.Control
        Me.radioOut.Cursor = System.Windows.Forms.Cursors.Default
        Me.radioOut.ForeColor = System.Drawing.Color.Blue
        Me.radioOut.Location = New System.Drawing.Point(152, 10)
        Me.radioOut.Name = "radioOut"
        Me.radioOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.radioOut.Size = New System.Drawing.Size(78, 21)
        Me.radioOut.TabIndex = 2
        Me.radioOut.TabStop = True
        Me.radioOut.Text = "Gateout"
        Me.radioOut.UseVisualStyleBackColor = False
        '
        'cmdAdd
        '
        Me.cmdAdd.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAdd.Location = New System.Drawing.Point(4, 498)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAdd.Size = New System.Drawing.Size(193, 33)
        Me.cmdAdd.TabIndex = 87
        Me.cmdAdd.Text = "Add Single Container"
        Me.cmdAdd.UseVisualStyleBackColor = False
        Me.cmdAdd.Visible = False
        '
        '_Label2_18
        '
        Me._Label2_18.AutoSize = True
        Me._Label2_18.BackColor = System.Drawing.Color.Transparent
        Me._Label2_18.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_18.ForeColor = System.Drawing.Color.Black
        Me._Label2_18.Location = New System.Drawing.Point(100, 97)
        Me._Label2_18.Name = "_Label2_18"
        Me._Label2_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_18.Size = New System.Drawing.Size(107, 17)
        Me._Label2_18.TabIndex = 117
        Me._Label2_18.Text = "Container Type:"
        '
        'Label2_12
        '
        Me.Label2_12.AutoSize = True
        Me.Label2_12.BackColor = System.Drawing.Color.Transparent
        Me.Label2_12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2_12.ForeColor = System.Drawing.Color.Black
        Me.Label2_12.Location = New System.Drawing.Point(316, 236)
        Me.Label2_12.Name = "Label2_12"
        Me.Label2_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2_12.Size = New System.Drawing.Size(37, 17)
        Me.Label2_12.TabIndex = 112
        Me.Label2_12.Text = "ETA:"
        '
        'Label2_11
        '
        Me.Label2_11.AutoSize = True
        Me.Label2_11.BackColor = System.Drawing.Color.Transparent
        Me.Label2_11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2_11.ForeColor = System.Drawing.Color.Black
        Me.Label2_11.Location = New System.Drawing.Point(12, 236)
        Me.Label2_11.Name = "Label2_11"
        Me.Label2_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2_11.Size = New System.Drawing.Size(93, 17)
        Me.Label2_11.TabIndex = 111
        Me.Label2_11.Text = "Shipping Line:"
        '
        '_Label2_10
        '
        Me._Label2_10.AutoSize = True
        Me._Label2_10.BackColor = System.Drawing.Color.Transparent
        Me._Label2_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_10.ForeColor = System.Drawing.Color.Black
        Me._Label2_10.Location = New System.Drawing.Point(12, 204)
        Me._Label2_10.Name = "_Label2_10"
        Me._Label2_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_10.Size = New System.Drawing.Size(88, 17)
        Me._Label2_10.TabIndex = 109
        Me._Label2_10.Text = "Vessel Name:"
        '
        'ComboFromCity
        '
        Me.ComboFromCity.Location = New System.Drawing.Point(2, 24)
        Me.ComboFromCity.Name = "ComboFromCity"
        Me.ComboFromCity.Size = New System.Drawing.Size(105, 24)
        Me.ComboFromCity.TabIndex = 67
        '
        'ComboFromLoc
        '
        Me.ComboFromLoc.Location = New System.Drawing.Point(106, 24)
        Me.ComboFromLoc.Name = "ComboFromLoc"
        Me.ComboFromLoc.Size = New System.Drawing.Size(129, 24)
        Me.ComboFromLoc.TabIndex = 68
        '
        'Text1
        '
        Me.Text1.AcceptsReturn = True
        Me.Text1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Location = New System.Drawing.Point(204, 671)
        Me.Text1.MaxLength = 0
        Me.Text1.Name = "Text1"
        Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1.Size = New System.Drawing.Size(297, 24)
        Me.Text1.TabIndex = 115
        '
        'Check1
        '
        Me.Check1.AutoSize = True
        Me.Check1.BackColor = System.Drawing.SystemColors.Control
        Me.Check1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check1.Location = New System.Drawing.Point(460, 242)
        Me.Check1.Name = "Check1"
        Me.Check1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check1.Size = New System.Drawing.Size(96, 21)
        Me.Check1.TabIndex = 114
        Me.Check1.Text = "Apply Zero"
        Me.Check1.UseVisualStyleBackColor = False
        Me.Check1.Visible = False
        '
        'ComboToCity
        '
        Me.ComboToCity.Location = New System.Drawing.Point(242, 24)
        Me.ComboToCity.Name = "ComboToCity"
        Me.ComboToCity.Size = New System.Drawing.Size(113, 24)
        Me.ComboToCity.TabIndex = 69
        '
        'picETA
        '
        Me.picETA.BackColor = System.Drawing.SystemColors.Control
        Me.picETA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picETA.Controls.Add(Me.txtEtaDay)
        Me.picETA.Controls.Add(Me.txtEtaMonth)
        Me.picETA.Controls.Add(Me.txtETAYear)
        Me.picETA.Controls.Add(Me._Label2_13)
        Me.picETA.Controls.Add(Me.Labelbar)
        Me.picETA.Cursor = System.Windows.Forms.Cursors.Default
        Me.picETA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picETA.Location = New System.Drawing.Point(356, 236)
        Me.picETA.Name = "picETA"
        Me.picETA.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.picETA.Size = New System.Drawing.Size(105, 24)
        Me.picETA.TabIndex = 113
        Me.picETA.TabStop = True
        '
        'txtEtaDay
        '
        Me.txtEtaDay.AcceptsReturn = True
        Me.txtEtaDay.BackColor = System.Drawing.SystemColors.Window
        Me.txtEtaDay.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEtaDay.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtEtaDay.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEtaDay.Location = New System.Drawing.Point(0, 0)
        Me.txtEtaDay.MaxLength = 2
        Me.txtEtaDay.Name = "txtEtaDay"
        Me.txtEtaDay.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEtaDay.Size = New System.Drawing.Size(25, 29)
        Me.txtEtaDay.TabIndex = 8
        '
        'txtEtaMonth
        '
        Me.txtEtaMonth.AcceptsReturn = True
        Me.txtEtaMonth.BackColor = System.Drawing.SystemColors.Window
        Me.txtEtaMonth.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEtaMonth.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEtaMonth.Location = New System.Drawing.Point(32, 0)
        Me.txtEtaMonth.MaxLength = 2
        Me.txtEtaMonth.Name = "txtEtaMonth"
        Me.txtEtaMonth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEtaMonth.Size = New System.Drawing.Size(25, 24)
        Me.txtEtaMonth.TabIndex = 9
        '
        'txtETAYear
        '
        Me.txtETAYear.AcceptsReturn = True
        Me.txtETAYear.BackColor = System.Drawing.SystemColors.Window
        Me.txtETAYear.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtETAYear.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtETAYear.Location = New System.Drawing.Point(64, 0)
        Me.txtETAYear.MaxLength = 4
        Me.txtETAYear.Name = "txtETAYear"
        Me.txtETAYear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtETAYear.Size = New System.Drawing.Size(41, 24)
        Me.txtETAYear.TabIndex = 10
        '
        '_Label2_13
        '
        Me._Label2_13.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me._Label2_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_13.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._Label2_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me._Label2_13.Location = New System.Drawing.Point(24, 0)
        Me._Label2_13.Name = "_Label2_13"
        Me._Label2_13.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me._Label2_13.Size = New System.Drawing.Size(9, 25)
        Me._Label2_13.TabIndex = 62
        Me._Label2_13.Text = "/"
        Me._Label2_13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Labelbar
        '
        Me.Labelbar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Labelbar.Cursor = System.Windows.Forms.Cursors.Default
        Me.Labelbar.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Labelbar.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Labelbar.Location = New System.Drawing.Point(56, 0)
        Me.Labelbar.Name = "Labelbar"
        Me.Labelbar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Labelbar.Size = New System.Drawing.Size(9, 25)
        Me.Labelbar.TabIndex = 61
        Me.Labelbar.Text = "/"
        Me.Labelbar.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.radioOut)
        Me.Frame1.Controls.Add(Me.radioIN)
        Me.Frame1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(212, 52)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(265, 39)
        Me.Frame1.TabIndex = 92
        Me.Frame1.Text = "Frame1"
        '
        'ComboToLoc
        '
        Me.ComboToLoc.Location = New System.Drawing.Point(362, 24)
        Me.ComboToLoc.Name = "ComboToLoc"
        Me.ComboToLoc.Size = New System.Drawing.Size(137, 24)
        Me.ComboToLoc.TabIndex = 70
        '
        'optEmpty
        '
        Me.optEmpty.BackColor = System.Drawing.SystemColors.Control
        Me.optEmpty.Checked = True
        Me.optEmpty.Cursor = System.Windows.Forms.Cursors.Default
        Me.optEmpty.ForeColor = System.Drawing.Color.Red
        Me.optEmpty.Location = New System.Drawing.Point(7, 3)
        Me.optEmpty.Name = "optEmpty"
        Me.optEmpty.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optEmpty.Size = New System.Drawing.Size(105, 21)
        Me.optEmpty.TabIndex = 78
        Me.optEmpty.TabStop = True
        Me.optEmpty.Text = "EMPTY"
        Me.optEmpty.UseVisualStyleBackColor = False
        '
        '_Label2_14
        '
        Me._Label2_14.BackColor = System.Drawing.Color.Transparent
        Me._Label2_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_14.ForeColor = System.Drawing.Color.Black
        Me._Label2_14.Location = New System.Drawing.Point(2, 8)
        Me._Label2_14.Name = "_Label2_14"
        Me._Label2_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_14.Size = New System.Drawing.Size(71, 17)
        Me._Label2_14.TabIndex = 74
        Me._Label2_14.Text = "Origin City"
        '
        'optFull
        '
        Me.optFull.BackColor = System.Drawing.SystemColors.Control
        Me.optFull.Cursor = System.Windows.Forms.Cursors.Default
        Me.optFull.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.optFull.Location = New System.Drawing.Point(159, 3)
        Me.optFull.Name = "optFull"
        Me.optFull.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optFull.Size = New System.Drawing.Size(89, 21)
        Me.optFull.TabIndex = 77
        Me.optFull.TabStop = True
        Me.optFull.Text = "FULL"
        Me.optFull.UseVisualStyleBackColor = False
        '
        'Frame5
        '
        Me.Frame5.BackColor = System.Drawing.SystemColors.Control
        Me.Frame5.Controls.Add(Me.optEmpty)
        Me.Frame5.Controls.Add(Me.optFull)
        Me.Frame5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Frame5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame5.Location = New System.Drawing.Point(212, 97)
        Me.Frame5.Name = "Frame5"
        Me.Frame5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame5.Size = New System.Drawing.Size(265, 29)
        Me.Frame5.TabIndex = 118
        Me.Frame5.Text = "Frame1"
        '
        'Frame4
        '
        Me.Frame4.BackColor = System.Drawing.SystemColors.Control
        Me.Frame4.Controls.Add(Me.ComboFromCity)
        Me.Frame4.Controls.Add(Me.ComboFromLoc)
        Me.Frame4.Controls.Add(Me.ComboToCity)
        Me.Frame4.Controls.Add(Me.ComboToLoc)
        Me.Frame4.Controls.Add(Me._Label2_14)
        Me.Frame4.Controls.Add(Me._Label2_15)
        Me.Frame4.Controls.Add(Me._Label2_16)
        Me.Frame4.Controls.Add(Me._Label2_17)
        Me.Frame4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Frame4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame4.Location = New System.Drawing.Point(12, 266)
        Me.Frame4.Name = "Frame4"
        Me.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame4.Size = New System.Drawing.Size(505, 56)
        Me.Frame4.TabIndex = 116
        Me.Frame4.Text = "Frame4"
        '
        '_Label2_15
        '
        Me._Label2_15.BackColor = System.Drawing.Color.Transparent
        Me._Label2_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_15.ForeColor = System.Drawing.Color.Black
        Me._Label2_15.Location = New System.Drawing.Point(242, 8)
        Me._Label2_15.Name = "_Label2_15"
        Me._Label2_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_15.Size = New System.Drawing.Size(78, 17)
        Me._Label2_15.TabIndex = 73
        Me._Label2_15.Text = "POL/ToCity"
        '
        '_Label2_16
        '
        Me._Label2_16.BackColor = System.Drawing.Color.Transparent
        Me._Label2_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_16.ForeColor = System.Drawing.Color.Black
        Me._Label2_16.Location = New System.Drawing.Point(106, 8)
        Me._Label2_16.Name = "_Label2_16"
        Me._Label2_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_16.Size = New System.Drawing.Size(104, 17)
        Me._Label2_16.TabIndex = 72
        Me._Label2_16.Text = "StuffedLocation"
        '
        '_Label2_17
        '
        Me._Label2_17.BackColor = System.Drawing.Color.Transparent
        Me._Label2_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_17.ForeColor = System.Drawing.Color.Black
        Me._Label2_17.Location = New System.Drawing.Point(362, 8)
        Me._Label2_17.Name = "_Label2_17"
        Me._Label2_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_17.Size = New System.Drawing.Size(130, 17)
        Me._Label2_17.TabIndex = 71
        Me._Label2_17.Text = "Destintion Unloaded"
        '
        'cmdChange
        '
        Me.cmdChange.BackColor = System.Drawing.SystemColors.Control
        Me.cmdChange.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdChange.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdChange.Location = New System.Drawing.Point(4, 658)
        Me.cmdChange.Name = "cmdChange"
        Me.cmdChange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdChange.Size = New System.Drawing.Size(193, 33)
        Me.cmdChange.TabIndex = 105
        Me.cmdChange.Text = "Change Booking Type"
        Me.cmdChange.UseVisualStyleBackColor = False
        Me.cmdChange.Visible = False
        '
        'txtRecitNo
        '
        Me.txtRecitNo.AcceptsReturn = True
        Me.txtRecitNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtRecitNo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRecitNo.Enabled = False
        Me.txtRecitNo.ForeColor = System.Drawing.Color.Blue
        Me.txtRecitNo.Location = New System.Drawing.Point(492, 148)
        Me.txtRecitNo.MaxLength = 0
        Me.txtRecitNo.Name = "txtRecitNo"
        Me.txtRecitNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRecitNo.Size = New System.Drawing.Size(257, 24)
        Me.txtRecitNo.TabIndex = 82
        Me.txtRecitNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRecitNo.Visible = False
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.SystemColors.Control
        Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Picture1.Controls.Add(Me.Command2)
        Me.Picture1.Controls.Add(Me.Command1)
        Me.Picture1.Controls.Add(Me.cmdExit)
        Me.Picture1.Controls.Add(Me.cmdSave)
        Me.Picture1.Controls.Add(Me.cmdCancel)
        Me.Picture1.Controls.Add(Me.cmdEdit)
        Me.Picture1.Controls.Add(Me.cmdNew)
        Me.Picture1.Controls.Add(Me.lblLabel)
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.Location = New System.Drawing.Point(0, 0)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(1543, 49)
        Me.Picture1.TabIndex = 93
        Me.Picture1.TabStop = True
        '
        'cmdNew
        '
        Me.cmdNew.BackColor = System.Drawing.SystemColors.Control
        Me.cmdNew.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdNew.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdNew.Location = New System.Drawing.Point(0, 8)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdNew.Size = New System.Drawing.Size(89, 33)
        Me.cmdNew.TabIndex = 0
        Me.cmdNew.Text = "Add New"
        Me.cmdNew.UseVisualStyleBackColor = False
        '
        'lblLabel
        '
        Me.lblLabel.AutoSize = True
        Me.lblLabel.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLabel.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblLabel.ForeColor = System.Drawing.Color.Red
        Me.lblLabel.Location = New System.Drawing.Point(824, 16)
        Me.lblLabel.Name = "lblLabel"
        Me.lblLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLabel.Size = New System.Drawing.Size(408, 22)
        Me.lblLabel.TabIndex = 47
        Me.lblLabel.Text = "Please Click On Save to Apply the Changes"
        Me.lblLabel.Visible = False
        '
        'txtB_Number
        '
        Me.txtB_Number.AcceptsReturn = True
        Me.txtB_Number.BackColor = System.Drawing.SystemColors.Window
        Me.txtB_Number.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtB_Number.Enabled = False
        Me.txtB_Number.ForeColor = System.Drawing.Color.Blue
        Me.txtB_Number.Location = New System.Drawing.Point(295, 167)
        Me.txtB_Number.MaxLength = 0
        Me.txtB_Number.Name = "txtB_Number"
        Me.txtB_Number.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtB_Number.Size = New System.Drawing.Size(174, 24)
        Me.txtB_Number.TabIndex = 79
        Me.txtB_Number.Text = "Text1"
        Me.txtB_Number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Command5
        '
        Me.Command5.BackColor = System.Drawing.SystemColors.Control
        Me.Command5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command5.Location = New System.Drawing.Point(128, 248)
        Me.Command5.Name = "Command5"
        Me.Command5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command5.Size = New System.Drawing.Size(105, 33)
        Me.Command5.TabIndex = 53
        Me.Command5.Text = "Cancel"
        Me.Command5.UseVisualStyleBackColor = False
        '
        'Combo1
        '
        Me.Combo1.BackColor = System.Drawing.Color.White
        Me.Combo1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Combo1.ForeColor = System.Drawing.Color.Black
        Me.Combo1.Location = New System.Drawing.Point(108, 236)
        Me.Combo1.Name = "Combo1"
        Me.Combo1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Combo1.Size = New System.Drawing.Size(207, 24)
        Me.Combo1.TabIndex = 81
        '
        'cmdAddMore
        '
        Me.cmdAddMore.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAddMore.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAddMore.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAddMore.Location = New System.Drawing.Point(4, 538)
        Me.cmdAddMore.Name = "cmdAddMore"
        Me.cmdAddMore.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAddMore.Size = New System.Drawing.Size(193, 33)
        Me.cmdAddMore.TabIndex = 107
        Me.cmdAddMore.Text = "Add Multiple Containers"
        Me.cmdAddMore.UseVisualStyleBackColor = False
        Me.cmdAddMore.Visible = False
        '
        'cmdAddVessel
        '
        Me.cmdAddVessel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAddVessel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAddVessel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAddVessel.Location = New System.Drawing.Point(460, 196)
        Me.cmdAddVessel.Name = "cmdAddVessel"
        Me.cmdAddVessel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAddVessel.Size = New System.Drawing.Size(25, 25)
        Me.cmdAddVessel.TabIndex = 110
        Me.cmdAddVessel.Text = "+"
        Me.cmdAddVessel.UseVisualStyleBackColor = False
        Me.cmdAddVessel.Visible = False
        '
        'Command4
        '
        Me.Command4.BackColor = System.Drawing.SystemColors.Control
        Me.Command4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command4.Location = New System.Drawing.Point(16, 248)
        Me.Command4.Name = "Command4"
        Me.Command4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command4.Size = New System.Drawing.Size(105, 33)
        Me.Command4.TabIndex = 52
        Me.Command4.Text = "Upload Units"
        Me.Command4.UseVisualStyleBackColor = False
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me.Command5)
        Me.Frame3.Controls.Add(Me.Command4)
        Me.Frame3.Controls.Add(Me.TxtEditCntno)
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(208, 402)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(289, 289)
        Me.Frame3.TabIndex = 106
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Add Multiple Units"
        Me.Frame3.Visible = False
        '
        'TxtEditCntno
        '
        Me.TxtEditCntno.AcceptsReturn = True
        Me.TxtEditCntno.BackColor = System.Drawing.SystemColors.Window
        Me.TxtEditCntno.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtEditCntno.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtEditCntno.Location = New System.Drawing.Point(0, 16)
        Me.TxtEditCntno.MaxLength = 0
        Me.TxtEditCntno.Multiline = True
        Me.TxtEditCntno.Name = "TxtEditCntno"
        Me.TxtEditCntno.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtEditCntno.Size = New System.Drawing.Size(281, 233)
        Me.TxtEditCntno.TabIndex = 50
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(12, 402)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(185, 97)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = resources.GetString("Label1.Text")
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label1.Visible = False
        '
        'dgBooking
        '
        Me.dgBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgBooking.Location = New System.Drawing.Point(523, 119)
        Me.dgBooking.Name = "dgBooking"
        Me.dgBooking.RowHeadersWidth = 51
        Me.dgBooking.RowTemplate.Height = 26
        Me.dgBooking.Size = New System.Drawing.Size(874, 576)
        Me.dgBooking.TabIndex = 119
        '
        'dtEmail
        '
        Me.dtEmail.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtEmail.Location = New System.Drawing.Point(204, 356)
        Me.dtEmail.Name = "dtEmail"
        Me.dtEmail.Size = New System.Drawing.Size(168, 24)
        Me.dtEmail.TabIndex = 120
        '
        'Booking_FullUnits
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1543, 859)
        Me.Controls.Add(Me.dtEmail)
        Me.Controls.Add(Me.dgBooking)
        Me.Controls.Add(Me.radioAuto)
        Me.Controls.Add(Me.radioManual)
        Me.Controls.Add(Me.txtB_Email)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.txtB_ID)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.txtCntNo)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me._Label2_9)
        Me.Controls.Add(Me._Label2_2)
        Me.Controls.Add(Me._Label2_0)
        Me.Controls.Add(Me._Label2_7)
        Me.Controls.Add(Me._Label2_1)
        Me.Controls.Add(Me._Label2_3)
        Me.Controls.Add(Me._Label2_4)
        Me.Controls.Add(Me._Label2_5)
        Me.Controls.Add(Me._Label2_6)
        Me.Controls.Add(Me.cmdCEdit)
        Me.Controls.Add(Me.ComboCustomer)
        Me.Controls.Add(Me.txtCntnoRT)
        Me.Controls.Add(Me.comboVessel)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me._Label2_18)
        Me.Controls.Add(Me.Label2_12)
        Me.Controls.Add(Me.Label2_11)
        Me.Controls.Add(Me._Label2_10)
        Me.Controls.Add(Me.Text1)
        Me.Controls.Add(Me.Check1)
        Me.Controls.Add(Me.picETA)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Frame5)
        Me.Controls.Add(Me.Frame4)
        Me.Controls.Add(Me.cmdChange)
        Me.Controls.Add(Me.txtRecitNo)
        Me.Controls.Add(Me.Picture1)
        Me.Controls.Add(Me.txtB_Number)
        Me.Controls.Add(Me.Combo1)
        Me.Controls.Add(Me.cmdAddMore)
        Me.Controls.Add(Me.cmdAddVessel)
        Me.Controls.Add(Me.Frame3)
        Me.Controls.Add(Me.Label1)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "Booking_FullUnits"
        Me.Text = "Booking_FullUnits"
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        CType(Me.txtCntnoRT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.picETA.ResumeLayout(False)
        Me.picETA.PerformLayout()
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.Frame5.ResumeLayout(False)
        Me.Frame4.ResumeLayout(False)
        Me.Picture1.ResumeLayout(False)
        Me.Picture1.PerformLayout()
        Me.Frame3.ResumeLayout(False)
        Me.Frame3.PerformLayout()
        CType(Me.dgBooking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents Command3 As Button
    Public WithEvents Option1 As RadioButton
    Public WithEvents Option2 As RadioButton
    Public WithEvents Option3 As RadioButton
    Public WithEvents radioAuto As RadioButton
    Public WithEvents radioManual As RadioButton
    Public WithEvents ComboSearch As ComboBox
    Public WithEvents Label3 As Label
    Public WithEvents txtB_Email As TextBox
    Public WithEvents radioIN As RadioButton
    Public WithEvents Command2 As Button
    Public WithEvents Frame2 As Panel
    Public WithEvents _Label2_8 As Label
    Public WithEvents txtB_ID As TextBox
    Public WithEvents Command1 As Button
    Public WithEvents cmdExit As Button
    Public WithEvents cmdSave As Button
    Public WithEvents cmdCancel As Button
    Public WithEvents cmdEdit As Button
    Public WithEvents txtQty As TextBox
    Public WithEvents txtCntNo As TextBox
    Public WithEvents cmdDelete As Button
    Public WithEvents _Label2_9 As Label
    Public WithEvents _Label2_2 As Label
    Public WithEvents _Label2_0 As Label
    Public WithEvents _Label2_7 As Label
    Public WithEvents _Label2_1 As Label
    Public WithEvents _Label2_3 As Label
    Public WithEvents _Label2_4 As Label
    Public WithEvents _Label2_5 As Label
    Public WithEvents _Label2_6 As Label
    Public WithEvents cmdCEdit As Button
    Public WithEvents ComboCustomer As ComboBox
    Public WithEvents txtCntnoRT As PictureBox
    Public WithEvents comboVessel As ComboBox
    Public WithEvents radioOut As RadioButton
    Public WithEvents cmdAdd As Button
    Public WithEvents _Label2_18 As Label
    Public WithEvents Label2_12 As Label
    Public WithEvents Label2_11 As Label
    Public WithEvents _Label2_10 As Label
    Public WithEvents ComboFromCity As ComboBox
    Public WithEvents ComboFromLoc As ComboBox
    Public WithEvents Text1 As TextBox
    Public WithEvents Check1 As CheckBox
    Public WithEvents ComboToCity As ComboBox
    Public WithEvents picETA As Panel
    Public WithEvents txtEtaDay As TextBox
    Public WithEvents txtEtaMonth As TextBox
    Public WithEvents txtETAYear As TextBox
    Public WithEvents _Label2_13 As Label
    Public WithEvents Labelbar As Label
    Public WithEvents Frame1 As Panel
    Public WithEvents ComboToLoc As ComboBox
    Public WithEvents optEmpty As RadioButton
    Public WithEvents _Label2_14 As Label
    Public WithEvents optFull As RadioButton
    Public WithEvents Frame5 As Panel
    Public WithEvents Frame4 As Panel
    Public WithEvents _Label2_15 As Label
    Public WithEvents _Label2_16 As Label
    Public WithEvents _Label2_17 As Label
    Public WithEvents cmdChange As Button
    Public WithEvents txtRecitNo As TextBox
    Public WithEvents Picture1 As Panel
    Public WithEvents cmdNew As Button
    Public WithEvents lblLabel As Label
    Public WithEvents txtB_Number As TextBox
    Public WithEvents Command5 As Button
    Public WithEvents txtSearch As TextBox
    Public WithEvents Combo1 As ComboBox
    Public WithEvents cmdAddMore As Button
    Public WithEvents cmdAddVessel As Button
    Public WithEvents Command4 As Button
    Public WithEvents Frame3 As GroupBox
    Public WithEvents TxtEditCntno As TextBox
    Public WithEvents Label1 As Label
    Friend WithEvents dgBooking As DataGridView
    Friend WithEvents dtEmail As DateTimePicker
End Class
