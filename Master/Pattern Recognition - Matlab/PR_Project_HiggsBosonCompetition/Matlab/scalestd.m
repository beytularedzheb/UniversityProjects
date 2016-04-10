function [data_scaled] = scalestd(data)
% scale data in order to have zero mean and unitary standart deviation
    mu = mean(data, 1)';
    s = std(data, [], 1)';
    data_scaled = (data' - repmat(mu, 1, size(data, 1))) ./ repmat(s, 1, size(data, 1));
    data_scaled = data_scaled';
end