load('data.mat')

% this part is executed 8 times: 4 SFS and 4 SBS with:
% mahalanobis, linear, quadratic, diagquadratic.
% 
% cvp = cvpartition(y, 'k', 10);
% opts = statset('display', 'iter');
% fun = @(xtrain, ytrain, xtest, ytest) sum(ytest ~= classify(xtest, xtrain, ytrain, 'mahalanobis'));
% [fs, history] = sequentialfs(fun, knnImputedData, y, 'cv', cvp, 'direction','backward','options', opts);
% 
% [inmodel,history] = sequentialfs(fun,X,...)
% inmodels array is created manually, using results from 'sequentialfs' and
% then it is created summ = sum(inmodels) and summ1 = sum(inmodels')
% 
% SFS/SBS - FEATURE SELECTION
summ1 = sum(inmodels');
figure;
bar(summ1);
ylabel('Number of features');
xlabel('Discriminant Type');
title('Sequential feature selection');
% discriminantTypes = ['Mahalanobis - SBS','Mahalanobis - SFS','Quadratic - SBS','Quadratic - SFS', 'Diagquadratic - SBS', 'Diagquadratic - SFS', 'Linear - SBS', 'Linear - SFS'];

summ = sum(inmodels);
figure;
bar(summ);
title('SFS feature assessment');
xlabel('Features');
ylabel('Number of selection');

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% ROC - FEATURE ASSESSMENT
% auc = roc_rank(knnImputedData, y, 0);
figure;
plot(auc)
bar(auc)
title('ROC - Feature Selection');
xlabel('Features');
ylabel('Rank');
title('ROC - Feature Assessment');
sel(size(sel,1)+1, :) = ones();

for i=1:size(auc,1)
    if (auc(i,1) <= 0.47)
        sel(size(sel,1), i) = 0;
    end
end

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Kruskal-Wallis
% chisq = kw_rank(knnImputedData, y);
figure;
bar(chisq);
xlabel('Features');
ylabel('Chi-sq');
title('Kruskal Wallis');

sel(size(sel,1)+1, :) = ones();
for i=1:size(chisq,1)
    if (chisq(i,1) <= 4700)
        sel(size(sel,1), i) = 0;
    end
end

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% ReliefF algorithm
% [rank, weight] = relieff(knnImputedData, y, 10);
% multiplies by 1000 in order to show selected prdictors
figure; bar(weight(rank) * 1000);
% hold on; plot(ones(1,30), 'r');
title('Importance of attributes (predictors) using ReliefF algorithm');
xlabel('Predictor rank');
ylabel('Predictor importance weight');
% hold off;

importanceReliefF = weight(rank) * 1000;
sel(size(sel,1)+1, :) = ones();
for i=1:size(importanceReliefF, 2)
    if (importanceReliefF(1, i) < 1)
       sel(size(sel, 1), i) = 0;
    end
end

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% 'sel' includes inmodels and results from ROC, Kruskal-Wallis, ReliefF
summ1All = sum(sel');

figure;
bar(summ1All);
ylabel('Number of features');
xlabel('Discriminant Type');
title('Feature selection - All (KW, ROC, ReliefF)');

summAll = sum(sel);
figure;
bar(summAll);
title('Feature selection - All (KW, ROC, ReliefF)');
xlabel('Features');
ylabel('Number of selection');

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% calculating how many features to select
selectedFeatures(1:size(summAll, 2)) = ones(); % selected features
featuresNumberForSel = ceil(rms(summ1All)); % root mean square and ceiling
sortedSummAll = sort(summAll, 'descend'); % sort the data in order to get
max = sortedSummAll(1, featuresNumberForSel); % value of the 'featuresNumberForSel'th feature

% if there are another features with value=max, they will be selected also.
for i=1:size(summAll, 2)
    if (summAll(1,i) < max)
        selectedFeatures(1, i) = 0;
    end
end

% numberOfSelectedFeatures = sum(selectedFeatures);

reduced_data = reduce_dimention(knnImputedData, selectedFeatures);
figure; ppatterns(reduced_data', y');