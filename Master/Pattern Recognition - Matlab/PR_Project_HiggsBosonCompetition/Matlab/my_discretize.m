function [result] = my_discretize(data, threshold)
%   threshold should be max: 5, usually 1, 0.5 or 0 (binarization)
%   because of the information on the mRMR's web site

    result = zeros(size(data));
    
    for i = 1 : size(data, 2)
        lLimit = mean(data(:, i)) - threshold * std(data(:, i));
        uLimit = mean(data(:, i)) + threshold * std(data(:, i));
        
        edges = (lLimit : uLimit);
        result(:, i) = discretize(data(:, i), edges);
    end	
end