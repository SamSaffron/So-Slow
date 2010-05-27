
IF OBJECT_ID(N'[dbo].[UserTotals]') is not null
	DROP VIEW [UserTotals]

GO

CREATE  view [dbo].[UserTotals]   
as   
select UserId, UserName, Reputation, Questions, [Answers], QUpvotes, QDownvotes, AUpvotes, ADownvotes  from   
(  
select  
 UserId = u.Id,   
 DisplayName as UserName,  
 u.Reputation as Reputation,  
 sum(case when p.ParentId is null then 1 else 0 end) as Questions,   
 sum(case when p.ParentId is not null then 1 else 0 end) as [Answers]   
from Users u  
join Posts p on p.OwnerUserId = u.Id   
where p.CommunityOwnedDate is null and p.ClosedDate is null  
group by u.Id, u.Reputation, DisplayName  
) as t   
join   
(  
 select   
  p.OwnerUserId,   
  QUpvotes = SUM(case when VoteTypeId = 2 and ParentId is null then 1 else 0 end),  
  QDownvotes = SUM(case when VoteTypeId = 3 and ParentId is null then 1 else 0 end),  
  AUpvotes = SUM(case when VoteTypeId = 2 and ParentId is not null then 1 else 0 end),  
  ADownvotes = SUM(case when VoteTypeId = 3 and ParentId is not null then 1 else 0 end)  
 from Votes v   
 join Posts p on p.Id = v.PostId  
 where VoteTypeId in (2,3) and p.CommunityOwnedDate is null and p.ClosedDate is null  
 group by OwnerUserId  
) as v on v.OwnerUserId = t.UserId  
  