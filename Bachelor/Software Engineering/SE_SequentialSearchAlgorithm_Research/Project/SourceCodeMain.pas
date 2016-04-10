unit SourceCodeMain;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, Grids, Buttons, GenFiles, UrsProfiler;

type

  TfrmMain = class(TForm)
    strGrdResult: TStringGrid;
    lbldEditSearch: TLabeledEdit;
    btnSearch: TSpeedButton;
    rdGrpChoiceFile: TRadioGroup;
    btnExit: TSpeedButton;
    lblInfo: TLabel;
    lblResult: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure btnSearchClick(Sender: TObject);
    procedure lbldEditSearchKeyPress(Sender: TObject; var Key: Char);
    procedure btnExitClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmMain: TfrmMain;


implementation

{$R *.dfm}


procedure TfrmMain.FormCreate(Sender: TObject);
begin
  GenerateRecordsAndSave;

  strGrdResult.Cells[1, 2] := rsProfiler[1].last;
  strGrdResult.Cells[2, 2] := rsProfiler[2].last;
  strGrdResult.Cells[3, 2] := rsProfiler[3].last;

  strGrdResult.Cells[1, 1] := msgFileSize50;
  strGrdResult.Cells[2, 1] := msgFileSize500;
  strGrdResult.Cells[3, 1] := msgFileSize5000;

  strGrdResult.Cells[1, 0] := 'Тест 1';
  strGrdResult.Cells[2, 0] := 'Тест 2';
  strGrdResult.Cells[3, 0] := 'Тест 3';
  strGrdResult.Cells[0, 1] := 'Обем [Bytes]';
  strGrdResult.Cells[0, 2] := 'Генериране [µs]';
  strGrdResult.Cells[0, 3] := 'Търсене [µs]';

  rdGrpChoiceFile.Buttons[0].Checked := true;


  
end;

procedure TfrmMain.btnSearchClick(Sender: TObject);
var
  searchNumber: integer;
  choicedFile: integer;
  colNum: integer;
begin
  choicedFile := 0;
  colNum := 0;
  if (lbldEditSearch.Text <> '') then begin

    searchNumber := StrToInt(lbldEditSearch.Text);

    if (rdGrpChoiceFile.Buttons[0].Checked = true) then begin
      choicedFile := 50;
      colNum := 1;
    end
    else if (rdGrpChoiceFile.Buttons[1].Checked = true) then begin
      choicedFile := 500;
      colNum := 2;
    end
    else if (rdGrpChoiceFile.Buttons[2].Checked = true) then begin
      choicedFile := 5000;
      colNum := 3;
    end;
    
    lblResult.Visible := true;

    if (SearchRecord(searchNumber, choicedFile) = true) then begin
      lblResult.Font.Color := clGreen;
      lblResult.Caption := 'Записът е намерен!';
    end
    else begin
      lblResult.Font.Color := clRed;
      lblResult.Caption := 'Записът НЕ е намерен!';
    end;

    strGrdResult.Cells[colNum, 3] := rsProfiler[0].last;

  end;
end;

procedure TfrmMain.lbldEditSearchKeyPress(Sender: TObject; var Key: Char);
begin
  if Key in ['0'..'9', #8, #13] = false then
    Key := #0
  else if Key = #13 then
    btnSearchClick(Sender);
end;

procedure TfrmMain.btnExitClick(Sender: TObject);
begin
  frmMain.Close;
end;

end.
