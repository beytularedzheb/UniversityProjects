function [scaled_data, classLabel, eventID, raw_data] = preprocessing(data_set)
% [data_set] - the data set, as it is given

% sort data by eventID, in order to get better result in imputation
% step (knnimpute)
    raw_data = sortrows(data_set, 1);
    eventID = raw_data(:, 1);
    raw_data(:, 1) = [];
    classLabel = raw_data(:, end);
    raw_data(:, end) = [];

    classLabel(classLabel == 1) = 0; % signal (positive class)
    classLabel(classLabel == 2) = 1; % background (negative class)
    
% substituting of missing values (-999) with NaN
    raw_data(raw_data == -999) = NaN;
%     scaled_data = inpaint_nans(raw_data, 4); % faster but gives worse result
    scaled_data = knnimpute(raw_data);
    scaled_data = scalestd(scaled_data);
%   discretized_data = my_discretize(scaled_data, 1);   
end