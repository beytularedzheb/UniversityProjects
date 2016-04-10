load('E:\РУ ''''Ангел Кънчев''''\5 Master\_Pattern Recognition\Project\higgs_data.mat')
data = sortrows(higgs_data_for_optimization, 1);
eventID = data(:, 1);
data(:, 1) = [];
y = data(:, end);
data(:, end) = [];

y(y == 1) = 0;
y(y == 2) = 1;

data(data == -999) = NaN;

% Change current directory where inpaint_nans.m and scalestd.m are
% nData = inpaint_nans(data, 4);
nData = knnimpute(data);
scaled_data = scalestd(nData);
% d_data = my_discretize(scaled_data, 1);

% Diagram which shows number of missing value in each feature
% column_names(1) = [];
% column_names(end) = [];
% 
% figure;
% barh(sum(isnan(data), 1) / size(data, 1));
% h = gca;
% h.YTick = 1:numel(column_names);
% h.YTickLabel = column_names;
% ylabel 'Predictor';
% xlabel 'Fraction of missing values';
% 
% cvp = cvpartition(y, 'Holdout', 0.3); % cross-validation data partition
% Xtrain = scaled_data(training(cvp), :);
% Ytrain = y(training(cvp));
% Xtest = scaled_data(test(cvp), :);
% Ytest = y(test(cvp));
% 
% tr.X = Xtrain';
% tr.y = Ytrain';
% tr.name = 'Higgs';
% tr.num_data = size(Xtrain, 1);
% tr.dim = size(Xtrain, 2);
% 
% d.X = scaled_data';
% d.y = y';
% d.name = 'Higgs';
% d.num_data = size(scaled_data, 1);
% d.dim = size(scaled_data, 2);