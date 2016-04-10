object formAbout: TformAbout
  Left = 280
  Top = 116
  Width = 795
  Height = 560
  Caption = 'About: Graphic Editor'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Arial'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  PixelsPerInch = 96
  TextHeight = 14
  object btnClose: TSpeedButton
    Left = 16
    Top = 475
    Width = 97
    Height = 33
    Caption = 'Close'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Arial'
    Font.Style = []
    ParentFont = False
    OnClick = btnCloseClick
  end
  object pnlContent: TPanel
    Left = 16
    Top = 16
    Width = 745
    Height = 449
    BevelInner = bvLowered
    BevelOuter = bvNone
    BevelWidth = 2
    Color = 16645629
    TabOrder = 0
    object lblAppName: TLabel
      Left = 136
      Top = 40
      Width = 443
      Height = 32
      Caption = 'Graphic Editor Of Logic Elements'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -27
      Font.Name = 'Arial'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object lblVersion: TLabel
      Left = 296
      Top = 120
      Width = 105
      Height = 18
      Caption = 'Version: 0.0.10'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Arial'
      Font.Style = []
      ParentFont = False
    end
    object lblBuil: TLabel
      Left = 264
      Top = 152
      Width = 176
      Height = 18
      Caption = 'Build: Nov 24 2013 23:05'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Arial'
      Font.Style = []
      ParentFont = False
    end
    object lblFacebook: TLabel
      Left = 192
      Top = 248
      Width = 82
      Height = 19
      Caption = 'Facebook:'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Arial'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object lblCreatedBy: TLabel
      Left = 240
      Top = 184
      Width = 77
      Height = 18
      Caption = 'Created by'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Arial'
      Font.Style = []
      ParentFont = False
    end
    object lblCrName: TLabel
      Left = 321
      Top = 184
      Width = 131
      Height = 19
      Caption = 'Beytula Redzheb'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Arial'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object lblCopyright: TLabel
      Left = 200
      Top = 352
      Width = 329
      Height = 16
      Caption = 'Copyright (C) 2013, Beytula Redzheb. All rights reserved.'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'Arial'
      Font.Style = []
      ParentFont = False
    end
    object lblInfo: TLabel
      Left = 112
      Top = 400
      Width = 470
      Height = 28
      Alignment = taCenter
      Caption = 
        'This program is free software; you can redistribute it and/or mo' +
        'dify it under the terms of the GNU General Public License versio' +
        'n 2 or later.'
      WordWrap = True
    end
    object lblUniversity: TLabel
      Left = 152
      Top = 80
      Width = 419
      Height = 16
      Caption = 'University of Rousse "Angel Kunchev", CST, ('#1048#1085#1090#1077#1075#1088#1080#1088#1072#1085#1080' '#1089#1088#1077#1076#1080') '
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'Arial'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object webAddress: TStaticText
      Left = 288
      Top = 248
      Width = 264
      Height = 22
      Cursor = crHandPoint
      Caption = 'https://www.facebook.com/thesilent91'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBlue
      Font.Height = -16
      Font.Name = 'Arial'
      Font.Style = [fsUnderline]
      ParentFont = False
      TabOrder = 0
      OnClick = webAddressClick
    end
  end
end
