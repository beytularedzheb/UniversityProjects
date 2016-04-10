function [labels, lblCods] = labelObjects(image)
    image = im2bw(image);
    labels = zeros(size(image));
% ������� � ��������� �� �������������, ����� ������������ ������� ���� 0.
% � ��� ��������� �� ���� �� �� ������� � 0, � ��������� �� ����������
% ������ � ����������� ���� �����.
    linkedWith = [];
    lblCods = [];
% ���������, � ����� �� ��������� ��� ������ � ��� ����� � �������
% ��� � �������������� ���� ������ ����� (� ������ ��� Cell Array)
    currentLabel = 1;
% ����������, ����� ������ ������ �� ������� ������. ��������� �� ������ 1
% ����� ���
    for row=1:size(image, 1)
        for column=1:size(image, 2)
            if (image(row, column))
                neighbors = getNeighbours(labels, column, row);
% ����� ��������� �� ������ ���� ������� �� ������� 1,2,3,4
                if (isempty(neighbors))
                    labels(row, column) = currentLabel;
                    linkedWith{currentLabel} = currentLabel;
                    currentLabel = currentLabel + 1;
                else
                    labels(row, column) = min(neighbors);
                    for label=1:length(neighbors)
                        linkedWith{neighbors(label)} = union(linkedWith{neighbors(label)}, neighbors);
                    end;
                end;
            end;
        end;
    end;
% ����� ���
    for row=1:size(image, 1)
        for column=1:size(image, 2)
            if (image(row, column))
                labels(row, column) = getMinLabel(labels(row, column), linkedWith);
                lblCods = union(lblCods, labels(row, column));
            end;
        end;
    end;