load('higgs_data.mat')
[X,y,~,rawData] = preprocessing(higgs_data_for_optimization);

% The diagram shows the fraction of missing values in each feature (predictor)
column_names(1) = [];
column_names(end) = [];

figure;
barh(sum(isnan(rawData), 1) / size(rawData, 1));
h = gca;
h.YTick = 1:numel(column_names);
h.YTickLabel = column_names;
ylabel 'Predictor';
xlabel 'Fraction of missing values';

% Plot raw and processed data
figure;
ppatterns(X',y');
title('Processed data');

figure;
ppatterns(rawData',y');
title('Raw data');

% Kruskal-Wallis Test on RAW data (with missing values)
chisq = kw_rank(rawData, y);
figure;
bar(chisq);
set(gca,'YGrid','on');  % horizontal grid
set(gca, 'XTick', [0:1:size(rawData, 2)]); % step by 1
xlabel('Features');
ylabel('Chi-sq');
title('Kruskal Wallis - Raw Data');

chisqX = kw_rank(X, y);
figure;
bar(chisqX);
set(gca,'YGrid','on');  % horizontal grid
set(gca, 'XTick', [0:1:size(X, 2)]); % step by 1
xlabel('Features');
ylabel('Chi-sq');
title('Kruskal Wallis - Imputed Data');

figure;
plot(chisqX,'DisplayName','chisqX');hold on;plot(chisq,'DisplayName','chisq');hold off;
legend('Raw data - KW', 'Imputed data - KW');
xlabel('Features');
ylabel('Rank');
title('Kruskal-Wallis Test - Diffrences Between Raw and Imputed Data');

% ROC - feature assessment
auc = roc_rank(X, y, 0);
figure; bar(auc); hold on; plot(ones(1, size(X, 2)) / 2, 'r'); hold off;

% PCA
[coeff,score,latent,~,explained,~] = pca(X); % uses Matlab's PCA
figure; stem(latent); hold on; plot(latent, 'r'); plot(ones(1,size(latent, 1))');hold off;
title('PCA - Kaiser Test');
xlabel('Features');
ylabel('Eigenvalue');

figure; ppatterns(score', y'); title('PCA score ploting');