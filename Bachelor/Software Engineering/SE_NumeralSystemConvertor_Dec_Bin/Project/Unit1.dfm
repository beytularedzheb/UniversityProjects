object Form1: TForm1
  Left = 512
  Top = 267
  Width = 400
  Height = 360
  Caption = #1050#1086#1085#1074#1077#1088#1090#1086#1088
  Color = clBtnFace
  Constraints.MaxHeight = 360
  Constraints.MaxWidth = 400
  Constraints.MinHeight = 360
  Constraints.MinWidth = 400
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  Menu = MainMenu1
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 16
    Top = 16
    Width = 235
    Height = 18
    Caption = #1042#1098#1074#1077#1076#1077#1090#1077' '#1095#1080#1089#1083#1086' '#1079#1072' '#1082#1086#1085#1074#1077#1088#1090#1080#1088#1072#1085#1077':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -15
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object Label2: TLabel
    Left = 16
    Top = 104
    Width = 68
    Height = 18
    Caption = #1056#1077#1079#1091#1083#1090#1072#1090':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -15
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object Label3: TLabel
    Left = 200
    Top = 248
    Width = 172
    Height = 18
    Caption = #1056#1077#1078#1080#1084' '#1085#1072' '#1082#1086#1085#1074#1077#1088#1090#1080#1088#1072#1085#1077':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -15
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object Button1: TButton
    Left = 288
    Top = 40
    Width = 81
    Height = 41
    Caption = #1050#1086#1085#1074#1077#1090#1080#1088#1072#1081
    TabOrder = 0
    OnClick = Button1Click
  end
  object RadioButton1: TRadioButton
    Left = 296
    Top = 280
    Width = 81
    Height = 17
    Caption = 'Bin to Dec'
    TabOrder = 1
  end
  object RadioButton2: TRadioButton
    Left = 200
    Top = 280
    Width = 81
    Height = 17
    Caption = 'Dec to Bin'
    Checked = True
    TabOrder = 2
    TabStop = True
  end
  object Button2: TButton
    Left = 16
    Top = 248
    Width = 81
    Height = 25
    Caption = #1048#1079#1095#1080#1089#1090#1080
    TabOrder = 3
    OnClick = Button2Click
  end
  object Edit2: TEdit
    Left = 16
    Top = 40
    Width = 265
    Height = 41
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -27
    Font.Name = 'Tahoma'
    Font.Style = []
    MaxLength = 20
    ParentFont = False
    TabOrder = 4
    OnKeyPress = Edit2KeyPress
  end
  object Memo2: TMemo
    Left = 16
    Top = 128
    Width = 353
    Height = 105
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Tahoma'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 5
    OnKeyPress = Memo2KeyPress
  end
  object MainMenu1: TMainMenu
    Left = 120
    Top = 96
    object N1: TMenuItem
      Caption = 'File'
      object Exit1: TMenuItem
        Caption = 'Exit'
        OnClick = Exit1Click
      end
    end
    object Edit1: TMenuItem
      Caption = 'Edit'
      object Clear1: TMenuItem
        Caption = 'Clear'
        OnClick = Clear1Click
      end
      object N2: TMenuItem
        Caption = '-'
      end
      object Cut1: TMenuItem
        Caption = 'Cut'
        ShortCut = 16472
        OnClick = Cut1Click
      end
      object Copy1: TMenuItem
        Caption = 'Copy'
        ShortCut = 16451
        OnClick = Copy1Click
      end
      object Paste1: TMenuItem
        Caption = 'Paste'
        ShortCut = 16470
        OnClick = Paste1Click
      end
    end
    object About1: TMenuItem
      Caption = 'Help'
      object About2: TMenuItem
        Caption = 'About'
        OnClick = About2Click
      end
    end
  end
  object PopupMenu1: TPopupMenu
    Left = 152
    Top = 96
    object Cut2: TMenuItem
      Caption = 'Cut'
      ShortCut = 16472
      OnClick = Cut2Click
    end
    object Copy2: TMenuItem
      Caption = 'Copy'
      ShortCut = 16451
      OnClick = Copy2Click
    end
    object Paste2: TMenuItem
      Caption = 'Paste'
      ShortCut = 16470
      OnClick = Paste2Click
    end
    object N4: TMenuItem
      Caption = '-'
    end
    object Clear2: TMenuItem
      Caption = 'Clear'
      OnClick = Clear2Click
    end
  end
end
