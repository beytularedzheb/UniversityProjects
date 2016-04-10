function [labels, lblCods] = labelObjects(image)
    image = im2bw(image);
    labels = zeros(size(image));
% матрица с размерите на изображението, която първоначално съдържа само 0.
% В нея пикселите от фона ще се кодират с 0, а пикселите от различните
% обекти с положителни цели числа.
    linkedWith = [];
    lblCods = [];
% структура, в която ще записваме кой етикет с кои други е свързан
% тук я инициализираме като празен масив (в Матлаб тип Cell Array)
    currentLabel = 1;
% променлива, която указва номера на текущия етикет. Започваме от етикет 1
% Първи пас
    for row=1:size(image, 1)
        for column=1:size(image, 2)
            if (image(row, column))
                neighbors = getNeighbours(labels, column, row);
% връща етикетите на всички бели пиксели на позиции 1,2,3,4
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
% Втори пас
    for row=1:size(image, 1)
        for column=1:size(image, 2)
            if (image(row, column))
                labels(row, column) = getMinLabel(labels(row, column), linkedWith);
                lblCods = union(lblCods, labels(row, column));
            end;
        end;
    end;