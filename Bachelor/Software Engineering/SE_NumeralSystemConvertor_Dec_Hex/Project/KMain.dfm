object frmMain: TfrmMain
  Left = 469
  Top = 225
  Width = 310
  Height = 215
  BorderIcons = [biSystemMenu, biMinimize]
  Caption = 
    #1050#1086#1085#1074#1077#1088#1090#1086#1088' '#1085#1072' '#1076#1077#1089#1077#1090#1080#1095#1085#1080' '#1095#1080#1089#1083#1072' '#1074' '#1096#1077#1089#1090#1085#1072#1076#1077#1089#1077#1090#1080#1095#1085#1072' '#1073#1088#1086#1081#1085#1072' '#1089#1080#1089#1090#1077#1084#1072' '#1080' ' +
    #1086#1073#1088#1072#1090#1085#1086
  Color = clBtnFace
  Constraints.MaxHeight = 215
  Constraints.MaxWidth = 310
  Constraints.MinHeight = 215
  Constraints.MinWidth = 310
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  Menu = frmMainMenu
  OldCreateOrder = False
  PopupMenu = frmPopupMenu
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object editNumb: TEdit
    Left = 15
    Top = 111
    Width = 265
    Height = 33
    BevelKind = bkTile
    BevelOuter = bvNone
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -21
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 0
    OnKeyPress = editNumbKeyPress
  end
  object btnConvert: TButton
    Left = 16
    Top = 66
    Width = 89
    Height = 30
    Caption = 'Convert'
    TabOrder = 1
    OnClick = btnConvertClick
  end
  object rdBtnGroupBox: TGroupBox
    Left = 121
    Top = 8
    Width = 157
    Height = 89
    TabOrder = 2
    object rdBtnToHex: TRadioButton
      Left = 8
      Top = 24
      Width = 113
      Height = 17
      Caption = 'Dec - Hex'
      Checked = True
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 0
      TabStop = True
    end
    object rdBtnToDec: TRadioButton
      Left = 8
      Top = 56
      Width = 113
      Height = 17
      Caption = 'Hex - Dec'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 1
    end
  end
  object frmMainMenu: TMainMenu
    Left = 16
    Top = 8
    object File1: TMenuItem
      Caption = 'File'
      object Exit1: TMenuItem
        Caption = 'Exit'
        ShortCut = 32883
        OnClick = Exit1Click
      end
    end
    object Edit2: TMenuItem
      Caption = 'Edit'
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
      object N1: TMenuItem
        Caption = '-'
      end
      object Clear1: TMenuItem
        Caption = 'Clear'
        ShortCut = 46
        OnClick = Clear1Click
      end
    end
    object Help1: TMenuItem
      Caption = 'Help'
      object About1: TMenuItem
        Caption = 'About'
        OnClick = About1Click
      end
    end
  end
  object frmPopupMenu: TPopupMenu
    Left = 48
    Top = 8
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
    object N2: TMenuItem
      Caption = '-'
    end
    object Clear2: TMenuItem
      Caption = 'Clear'
      ShortCut = 46
      OnClick = Clear2Click
    end
  end
end
