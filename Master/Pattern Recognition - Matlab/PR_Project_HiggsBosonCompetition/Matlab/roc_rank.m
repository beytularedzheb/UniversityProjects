function [AUC] = roc_rank(data, y, posclass)
    AUC = zeros(size(data, 2), 1);

    for i = 1:size(data, 2)
        [~,~,~,AUCcurr] = perfcurve(y, data(:, i), posclass);

        AUC(i,1) = AUCcurr;
    end
end