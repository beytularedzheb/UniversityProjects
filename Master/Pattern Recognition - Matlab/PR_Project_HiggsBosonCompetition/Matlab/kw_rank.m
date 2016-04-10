function [chisq] = kw_rank(data, y)
    chisq = zeros(size(data, 2), 1);

    for i = 1:size(data, 2)
        [~, table, ~] = kruskalwallis(data(:, i), y, 'off');

        chisq(i, 1) = cell2mat( table(2, 5) );
    end
end

% figure;
% bar(chisq);
% set(gca,'YGrid','on');  % horizontal grid
% set(gca, 'XTick', [0:1:size(rawData, 2)]); % step by 1
% xlabel('Features');
% ylabel('Chi-sq');
% title('Kruskal Wallis');