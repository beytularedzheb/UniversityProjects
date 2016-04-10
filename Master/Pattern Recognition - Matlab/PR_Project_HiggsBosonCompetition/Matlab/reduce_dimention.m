function [reduced_data] = reduce_dimention(X, selectedFeatures)
% INPUT:
% X - data for reducing. KxN, where K 0 number of samples, N - number of features
% selectedFeatures - 1xN, where N is number of features. Contains only 0 and 1
% 1 means that feature is selected and 0 - not
% OUTPUT
% reduced_data - data which is reduced to KxM

    if (size(X, 2) == size(selectedFeatures, 2))
        reduced_data(size(X,1), sum(selectedFeatures)) = zeros();
        redIndex = 1;
        
        for i=1:size(X, 2)
            if (selectedFeatures(1, i) > 0)
               reduced_data(:, redIndex) = X(:, i);
               redIndex = redIndex + 1;
            end
        end
    else
        fprintf('The columns number of X and selectedFeatures must be equals!\n');
        reduced_data = [];
    end
end