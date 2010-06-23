-- run me after the import

create table #t (Id int, ActualScore int) 

insert #t 
select Id, (
  select sum(case when VoteTypeId = 2 then 1 else -1 end)
  from Votes 
  where p.Id = PostId and VoteTypeId in (2,3)
) [ActualScore] from Posts p

where (
  select sum(case when VoteTypeId = 2 then 1 else -1 end)
  from Votes 
  where p.Id = PostId and VoteTypeId in (2,3)
) <> Score 


update p set Score = ActualScore 
from Posts p 
join #t on #t.id = p.id 