object Form1: TForm1
  Left = 1339
  Top = 330
  AutoSize = True
  BorderIcons = [biSystemMenu, biMinimize]
  BorderStyle = bsSingle
  BorderWidth = 2
  Caption = 'Calculator TS v 1.0'
  ClientHeight = 290
  ClientWidth = 218
  Color = clInactiveBorder
  Constraints.MaxHeight = 360
  Constraints.MaxWidth = 240
  Constraints.MinHeight = 300
  Constraints.MinWidth = 218
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowFrame
  Font.Height = -13
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 120
  TextHeight = 16
  object Edit1: TEdit
    Left = 0
    Top = 0
    Width = 217
    Height = 54
    Cursor = crIBeam
    BevelOuter = bvSpace
    BiDiMode = bdLeftToRight
    Color = clInactiveBorder
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clMaroon
    Font.Height = -28
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    MaxLength = 10
    ParentBiDiMode = False
    ParentFont = False
    ReadOnly = True
    TabOrder = 0
  end
  object Button2: TButton
    Left = 56
    Top = 60
    Width = 50
    Height = 30
    Cursor = crHandPoint
    Caption = 'cos()'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 1
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 112
    Top = 60
    Width = 50
    Height = 30
    Cursor = crHandPoint
    Caption = 'arctg()'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 2
    OnClick = Button3Click
  end
  object Button4: TButton
    Left = 0
    Top = 60
    Width = 50
    Height = 30
    Cursor = crHandPoint
    Caption = 'sin()'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 3
    OnClick = Button4Click
  end
  object Button5: TButton
    Left = 0
    Top = 140
    Width = 50
    Height = 30
    Cursor = crHandPoint
    Caption = '7'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 4
    OnClick = Button5Click
  end
  object Button6: TButton
    Left = 112
    Top = 140
    Width = 50
    Height = 30
    Cursor = crHandPoint
    Caption = '9'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 5
    OnClick = Button6Click
  end
  object Button7: TButton
    Left = 0
    Top = 100
    Width = 50
    Height = 30
    Cursor = crHandPoint
    Caption = 'C'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 6
    OnClick = Button7Click
  end
  object Button8: TButton
    Left = 56
    Top = 140
    Width = 50
    Height = 30
    Cursor = crHandPoint
    Caption = '8'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 7
    OnClick = Button8Click
  end
  object Button9: TButton
    Left = 0
    Top = 180
    Width = 50
    Height = 30
    Cursor = crHandPoint
    Caption = '4'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 8
    OnClick = Button9Click
  end
  object Button10: TButton
    Left = 112
    Top = 180
    Width = 50
    Height = 30
    Cursor = crHandPoint
    Caption = '6'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 9
    OnClick = Button10Click
  end
  object Button11: TButton
    Left = 168
    Top = 140
    Width = 50
    Height = 30
    Cursor = crHandPoint
    Caption = '/'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 10
    OnClick = Button11Click
  end
  object Button12: TButton
    Left = 56
    Top = 180
    Width = 50
    Height = 30
    Cursor = crHandPoint
    Caption = '5'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 11
    OnClick = Button12Click
  end
  object Button13: TButton
    Left = 0
    Top = 220
    Width = 50
    Height = 30
    Cursor = crHandPoint
    Caption = '1'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 12
    OnClick = Button13Click
  end
  object Button14: TButton
    Left = 112
    Top = 220
    Width = 50
    Height = 30
    Cursor = crHandPoint
    Caption = '3'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 13
    OnClick = Button14Click
  end
  object Button15: TButton
    Left = 168
    Top = 180
    Width = 50
    Height = 30
    Cursor = crHandPoint
    Caption = '*'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 14
    OnClick = Button15Click
  end
  object Button16: TButton
    Left = 56
    Top = 220
    Width = 50
    Height = 30
    Cursor = crHandPoint
    Caption = '2'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 15
    OnClick = Button16Click
  end
  object Button18: TButton
    Left = 168
    Top = 60
    Width = 50
    Height = 30
    Cursor = crHandPoint
    Caption = 'exp()'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 16
    OnClick = Button18Click
  end
  object Button19: TButton
    Left = 168
    Top = 260
    Width = 50
    Height = 30
    Cursor = crHandPoint
    Caption = '+'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 17
    OnClick = Button19Click
  end
  object Button17: TButton
    Left = 0
    Top = 260
    Width = 50
    Height = 30
    Cursor = crHandPoint
    Caption = '0'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 18
    OnClick = Button17Click
  end
  object Button21: TButton
    Left = 112
    Top = 260
    Width = 50
    Height = 30
    Cursor = crHandPoint
    Caption = '='
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 19
    OnClick = Button21Click
  end
  object Button22: TButton
    Left = 168
    Top = 220
    Width = 50
    Height = 30
    Cursor = crHandPoint
    Caption = '-'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 20
    OnClick = Button22Click
  end
  object Button23: TButton
    Left = 56
    Top = 260
    Width = 50
    Height = 30
    Cursor = crHandPoint
    Caption = ','
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 21
    OnClick = Button23Click
  end
  object Button25: TButton
    Left = 112
    Top = 100
    Width = 50
    Height = 30
    Cursor = crHandPoint
    Caption = 'sqr()'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 22
    OnClick = Button25Click
  end
  object Button26: TButton
    Left = 168
    Top = 100
    Width = 50
    Height = 30
    Cursor = crHandPoint
    Caption = 'ln()'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 23
    OnClick = Button26Click
  end
  object Button27: TButton
    Left = 56
    Top = 100
    Width = 50
    Height = 30
    Cursor = crHandPoint
    Caption = 'sqrt()'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Segoe Script'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 24
    OnClick = Button27Click
  end
end
