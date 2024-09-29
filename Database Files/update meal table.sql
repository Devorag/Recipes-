
;
with x as (
	select
	'Breakfast Bash' as mealName, 
	'Start your day off right with this lively breakfast spread that brings together a variety of delicious and energizing dishes.
	From a delicious cheese bread and butter muffins to a refreshing smoothie, the breakfast bash offers a hearty start to your morning.' as mealdescription
	union all 
	select
	'Brunch o'' Lunch', 
	'A delightful fusion of breakfast and lunch favorites, Brunch o'' lunch provides the 
	perfect mid-day meal experience. Enjoy chocolate chip coookies, muddy buddies, and flavorful soup that will satisfy your hunger and brighten your day.'
	union all 
	select 
	'Noon Refreshments' ,
	'Beat the midday slump with a selection of light and refreshing dishes designed to revitalize and refresh. Noon refreshments features
	roasted vegetables and falafel balls making it an ideal choice for a rejuvenating lunch break.'
	union all 
	select 
	'Supper Crunch',
	'End your day on a high note with supper crunch, a delicious evening meal that offers a mix of comforting and satisfying dishes.
	Enjoy a delicious sesame chicken that makes supper a truly enjoyable experience.'

)
update m 
set m.mealDescription = x.MealDescription
from meal m 
join x on m.MealName = x.MealName
go