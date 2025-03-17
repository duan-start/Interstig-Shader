#version 330 core

out vec4 FragColor;
in vec2 Pos;
in vec2 stand;
in vec2 screen;
uniform float iTime;

#define t iTime
#define r screen.xy

//一种美感函数
vec3 palette(float t){
vec3 a=vec3 (.5,.5,.5);
vec3 b=vec3 (.5,.5,.5);
vec3 c=vec3 (1.,1.,1.);
vec3 d=vec3 (0.263,.416,.557);
    return a+b*cos( 6.28318*(c*t+d));
    }

void main(){
vec2 uv =stand;
uv.x*=screen.x/screen.y;
//获取屏幕的周期性变化
vec2 uv0=uv;
//方便重复和迭代；
vec3 final=vec3(0.,0.,0.);

for(float i=0.;i<4.;i++){

  //截断
  uv=fract(uv*1.5)-0.5;
  float d=length(uv)*exp(-length(uv0));
  
  //这个传参好奇怪啊
  vec3 col=palette(length(uv0)+i*.4+t*.4);
  //时间参数，震荡循环
  d = sin(d*8.+t)/8.;
  d=abs(d);
  //step 函数，保证小于这个的数值全部设置为0
  //d=step(0.1,d);
  
  //smoothstep 函数，数值之间的平滑过度
  // d=smoothstep(0.,0.1,d);
  //反函数的美感，而非直接使用smooth
  d=pow(0.01/d,1.2);
  final+=col*d;
}


FragColor=vec4(final,0.);

}